using System;

public class Item
{
    public String Nome { get; set; }
    public String Descricao { get; set; }
    public String Categoria { get; set; }
    public Int32 Valor { get; set; }

    public Item(String nome, String descricao, String categoria, Int32 valor)
    {
        Nome = nome;
        Descricao = descricao;
        Categoria = categoria;
        Valor = valor;
    }
}