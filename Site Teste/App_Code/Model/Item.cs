using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Item
/// </summary>
public class Item
{
    public Item(Locacao locacao)
    {
        ObjLocacao = locacao;
    }
    public int ItemID { get; set; }


    public Locacao ObjLocacao { get; set; }
    public Veiculo ObjVeiculo { get; set; }

}