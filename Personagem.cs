using System;
using System.Collections.Generic;

public class Personagem
{
    public String Nome;
    public Int32 Ouro;
    public List<Item> Inventario = new List<Item>();

    public Loja ComprarItem(string nomeDoItem, int quantidade, Loja lojaAtual)
    {
        if (quantidade > 1)
        {
            for (int i = 0; i < quantidade; i++)
            {
                Inventario.Add(lojaAtual.VenderItem(nomeDoItem));
            }
        }
        else if (quantidade == 1)
        {
            Inventario.Add(lojaAtual.VenderItem(nomeDoItem));
        }
        return lojaAtual;
    }
}