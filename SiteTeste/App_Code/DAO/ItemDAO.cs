using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Descrição resumida de ItemDAO
/// </summary>
public class ItemDAO
{
    Database banco = Database.Open("ConexaoBanco");
    public int Gravar(Locacao locacao)
    {
        int cont = 0;
        foreach (var item in locacao.ListaItem)
        {
            var sql = "Insert Into Itens(emprestimoID,livroID)values(@0,@1)";
            banco.Execute(sql, item.ObjLocacao.CodLocacao, item.ObjVeiculo.VeiculoID);
            cont++;
        }
        return cont;
    }

}