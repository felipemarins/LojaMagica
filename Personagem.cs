using System;
using System.Collections.Generic;

public class Personagem
{
	public String Nome;
	public Int32 Ouro;
	public Dictionary<string, Tuple<Item, int>> Inventario = new Dictionary<string, Tuple<Item, int>>();

	public Loja ComprarItem(string nomeDoItem, int quantidade, Loja lojaAtual)
	{
		if (lojaAtual.ItemExiste(nomeDoItem))
		{
			if (lojaAtual.RetornarQuantidadeItem(nomeDoItem) >= quantidade)
			{
				Item itemSelecionado = lojaAtual.RetornarItem(nomeDoItem);
				int valorTotal = itemSelecionado.Valor * quantidade;
				if (valorTotal <= Ouro)
				{
					Console.Clear();
					Menu confirmacaoDeCompra = new Menu(
						"Item: " + itemSelecionado.Nome +
						"\nValor: " + itemSelecionado.Valor +
						"\nUnidades a se comprar: " + quantidade +
						"\nValor total: " + valorTotal +
						"\n\nTem certeza de que deseja realizar esta compra?",
						new List<string> { "Sim", "Não" });
					confirmacaoDeCompra.IniciarMenuPadrao();
					if (confirmacaoDeCompra.Selecao == 1)
					{
						if (quantidade > 1)
						{
							for (int i = 0; i < quantidade; i++)
							{
								lojaAtual.VenderItem(nomeDoItem);
							}
						}
						else if (quantidade == 1)
						{
							lojaAtual.VenderItem(nomeDoItem);
						}

						if (this.Inventario.ContainsKey(nomeDoItem))
						{
							quantidade += this.Inventario[nomeDoItem].Item2;
							this.Inventario[nomeDoItem] = new Tuple<Item, int>(this.Inventario[nomeDoItem].Item1, quantidade);
						}
						else
						{
							this.Inventario.Add(nomeDoItem, new Tuple<Item, int>(itemSelecionado, quantidade));
						}
					}
				}
				else
				{
					Console.WriteLine("Você não tem dinheiro suficiente para comprar esse item.");
				}
			}
			else
			{
				Console.WriteLine("A loja não tem " + quantidade + " unidades desse item.");
			}
		}
		Menu.EsperarPorTecla();
		return lojaAtual;
	}
}