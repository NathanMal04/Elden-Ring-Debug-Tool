using System;
using FSParam;

namespace Erd_Tools.Models.Params.Defs
{
    /// <summary>
    /// [Erd-Tools fork] Reconstructed param-row wrapper for EquipParamGoods.
    ///
    /// The original source for this class was not committed to the Erd-Tools submodule at the
    /// pinned commit, and — unlike <see cref="EquipParamWeapon"/> — it does NOT exist in the
    /// compiled v0.8.6.2 assembly either (the goods-categorisation feature postdates that public
    /// build), so there is no authoritative original to lift. Only the surface ErdHook uses is
    /// implemented: the constructor from an FSParam row and <see cref="getGoodsTypeName"/>, whose
    /// return value is used purely as the UI category label / grouping key for goods.
    ///
    /// The category names are a functional best-effort mapping of Elden Ring's <c>goodsType</c>
    /// (GOODS_TYPE) field. Well-known values get readable names; any other value is bucketed
    /// distinctly by its numeric type so every good remains categorised and spawnable. The exact
    /// labels/grouping may differ from upstream's intended design and can be refined later.
    ///
    /// Note: FSParam types are fully qualified on purpose — an enclosing <c>Erd_Tools.Models.Param</c>
    /// exists, so an unqualified <c>Param</c> would bind to the wrong type.
    /// </summary>
    public class EquipParamGoods
    {
        public int goodsType { get; }

        public EquipParamGoods(FSParam.Param.Row row)
        {
            goodsType = Convert.ToInt32(row.GetCellHandleOrThrow("goodsType").Value);
        }

        public string getGoodsTypeName()
        {
            return goodsType switch
            {
                0 => "Normal Item",
                1 => "Key Item",
                2 => "Crafting Material",
                _ => $"Goods (Type {goodsType})",
            };
        }
    }
}
