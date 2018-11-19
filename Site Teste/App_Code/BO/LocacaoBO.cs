using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VeiculoBO
/// </summary>
public class LocacaoBO
{

    public IList<Locacao> ListaLocacoes()
    {
        return new LocacaoDAO().ListaLocacoes();
    }
    public Locacao Buscar(int codLocacao)
    {
        return new LocacaoDAO().Buscar(codLocacao);
    }
    public void Excluir(int codLocacao)
    {
        new LocacaoDAO().Excluir(codLocacao);

    }
}