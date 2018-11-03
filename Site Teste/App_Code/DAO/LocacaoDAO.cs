using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for ClienteDAO
/// </summary>
public class LocacaoDAO
{
    Database banco = Database.Open("ConexaoBanco");


    public Locacao Gravar(Locacao locacao)
    {
        var sql = "Insert Into Cliente(dataInicio, dataEntrega, totalCusto, clienteID, veiculoID)values(@0,@1,@2,@3,@4)";
        banco.Execute(sql, locacao.DataInicio, locacao.DataEntrega, locacao.TotalCusto, locacao.ObjCliente.ClienteID, locacao.ObjVeiculo.VeiculoID);
        var ultimoID = banco.GetLastInsertId();
        return Buscar(ultimoID);

    }



 


    public IList<Locacao> ListaLocacoes()
    {
        IList<Locacao> lista = new List<Locacao>();
        var sql = "Select * From Locacao";
        var resultado = banco.Query(sql);
        if (resultado.Count() > 0)
        {
            Locacao objLocacao;
            foreach (var item in resultado)
            {
                objLocacao = new Locacao

                {
                    CodLocacao = item.codLocacao,
                    DataInicio = item.dataInicio,
                    DataEntrega = item.dataEntrega,
                    TotalCusto = Convert.ToDouble(item.totalCusto),
                    ObjCliente = new ClienteDAO().Buscar((int) item.clienteID),
                    ObjVeiculo = new VeiculoDAO().Buscar((int) item.veiculoID)
                    
                    
                };
                lista.Add(objLocacao);
            }
            banco.Close();
        }
        else
        {
            banco.Close();
            return null;
        }
        return lista;
    }

   
    public void Excluir(int codLocacao)
    {
        var sql = "Delete from Locacao where codLocacao=@0";
        banco.Execute(sql, codLocacao);
        banco.Close();
    }



    public Locacao Buscar(int locacaoID)
    {
        var sql = "Select * From Locacao Where codLocacao = @0";
        var resultado = banco.QuerySingle(sql, locacaoID);
        Locacao objLocacao = new Locacao
        {
            CodLocacao = resultado.codLocacao,
            DataInicio = resultado.dataInicio,
            DataEntrega = resultado.dataEntrega,
            TotalCusto = Convert.ToDouble(resultado.totalCusto),
            ObjCliente = resultado.clienteID,
            ObjVeiculo = resultado.veiculoID
        };
        banco.Close();
        return objLocacao;

    }



}