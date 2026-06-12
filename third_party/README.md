# third_party

Vendored dependencies that `Erd-Tools` requires but that are **not** committed to the
Erd-Tools submodule upstream. Nordgaren builds with these present locally, so a fresh
clone (and CI) cannot compile without them. They are dropped into the submodule's
expected paths at build time — by the `vendor FSParam + StudioUtils into Erd-Tools
submodule` step in [.github/workflows/build.yml](../.github/workflows/build.yml), and
locally via the command below.

## Contents

- **FSParam/** — `Erd-Tools.csproj` references `..\FSParam\FSParam.csproj`; `ErdHook.cs`
  uses `FSParam.Param.Read(...)` / `FSParam.Param.Row` for live-read params.
- **StudioUtils/** — required by `FSParam.csproj` (`StridedByteArray`).
- **ErdToolsDefs/** — Erd-Tools' own `Erd_Tools.Models.Params.Defs.*` classes, referenced by
  `ErdHook.cs` but never committed to the submodule at this pin. All files here are copied into
  `src/Erd-Tools/src/Erd-Tools/Models/Params/Defs/`.
  - **EquipParamWeapon.cs** — the `wepType` discriminator ErdHook needs. The `WeaponType` enum
    values were recovered from the **compiled v0.8.6.2 assembly** (extracted from the single-file
    exe) and cross-checked against `Models/Items/Weapon.cs`, so the numeric codes are authoritative.
    Member names follow ErdHook's usage (the refactor renamed some DLC entries and merged the ammo
    codes into `WeaponType`).
  - **EquipParamGoods.cs** — `getGoodsTypeName()` used as the goods UI category label. This logic
    does NOT exist in v0.8.6.2 (postdates it) and was never committed, so there is no authoritative
    original. It's a functional best-effort mapping of the `goodsType` field: well-known values get
    readable names, others are bucketed distinctly by number. Every good stays spawnable; labels may
    differ from upstream's intended grouping.

  Note: FSParam types are fully qualified (`FSParam.Param.Row`) in these files — an enclosing
  `Erd_Tools.Models.Param` exists, so an unqualified `Param` binds to the wrong type.
- **patches/propertyhook-autorefresh-no-crash.patch** — applied to the PropertyHook submodule by
  the `patch PropertyHook submodule` CI step (`git -C src/Erd-Tools/src/PropertyHook apply ...`).
  PropertyHook's `AutoRefresh` background thread calls `Refresh()` with no exception handling; an
  unhandled exception on a background thread terminates the whole .NET app. `Refresh()` can throw
  transiently — observed under Wine/Proton as `Win32Exception (5): Access denied` from
  `Process.MainModule` when the tool and game sit in different pressure-vessel containers — which
  crashed the tool on startup. The patch wraps the call in try/catch so it retries on the next tick.

## Provenance

Both are the original pre-"Andre" projects from **soulsmods/DSMapStudio**, taken from
commit `4c28a09d20776b03ef03d1c6227f4e70529a612e` (2023-10-19), the parent of the commit
that renamed them into `Andre`. Original paths: `src/Studio.Core/FSParam` and
`src/Studio.Core/StudioUtils`.

## Patches applied (vs. upstream DSMapStudio)

1. Retargeted to match Erd-Tools: `FSParam.csproj` `net7.0-windows` → `net6.0-windows`;
   `StudioUtils.csproj` `net7.0` → `net6.0`. `LangVersion` `11` → `10` (the workflow
   installs the .NET 6 SDK; no C# 11 features are used).
2. `Param.cs` `ApplyParamdef`: removed the DSMapStudio regulation-version field filter
   (`def.VersionAware && field.IsValidForRegulationVersion(...)`) — those members don't
   exist in Nordgaren's `er`-branch SoulsFormats. All fields are treated as valid.
3. `Param.cs` write path: `bw.WriteBytes(data)` → `bw.WriteBytes(data.ToArray())` —
   Nordgaren's `BinaryWriterEx.WriteBytes` takes `byte[]`, not `Span<byte>`. (Write path
   is unused by Erd-Tools, which only reads.)

FSParam + StudioUtils + SoulsFormats verified to compile together against the Erd-Tools
submodule's SoulsFormats.

## Local build

Run from the repo root before building the solution (mirrors the CI step):

```pwsh
# PowerShell (Windows)
New-Item -ItemType Directory -Force -Path src/Erd-Tools/src/Erd-Tools/Models/Params/Defs | Out-Null
Copy-Item third_party/FSParam/*      src/Erd-Tools/src/FSParam     -Recurse -Force
Copy-Item third_party/StudioUtils/*  src/Erd-Tools/src/StudioUtils -Recurse -Force
Copy-Item third_party/ErdToolsDefs/* src/Erd-Tools/src/Erd-Tools/Models/Params/Defs -Recurse -Force
```

```bash
# bash
mkdir -p src/Erd-Tools/src/FSParam src/Erd-Tools/src/StudioUtils src/Erd-Tools/src/Erd-Tools/Models/Params/Defs
cp -r third_party/FSParam/*      src/Erd-Tools/src/FSParam/
cp -r third_party/StudioUtils/*  src/Erd-Tools/src/StudioUtils/
cp -r third_party/ErdToolsDefs/* src/Erd-Tools/src/Erd-Tools/Models/Params/Defs/
```
