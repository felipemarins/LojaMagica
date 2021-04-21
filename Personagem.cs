using System;
using System.Collections.Generic;

public class Personagem
{
	public String Nome;
	public Int32 Ouro;
	public List<Item> Inventario = new List<Item>();

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
					Console.WriteLine("Item: " + itemSelecionado.Nome);
					Console.WriteLine("Valor: " + itemSelecionado.Valor);
					Console.WriteLine("Unidades a se comprar: " + quantidade);
					Console.WriteLine("Valor total: " + valorTotal);

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
								this.Inventario.Add(lojaAtual.VenderItem(nomeDoItem));
							}
						}
						else if (quantidade == 1)
						{
							this.Inventario.Add(lojaAtual.VenderItem(nomeDoItem));
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