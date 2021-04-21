using System;
using System.Collections.Generic;

public class Personagem
{
	public String Nome;
	public Int32 Ouro;
	public Dictionary<string, Tuple<Item, int>> Inventario = new Dictionary<string, Tuple<Item, int>>();

	public Personagem(String nome, Int32 ouro)
	{
		this.Nome = nome;
		this.Ouro = ouro;
	}
	public void ImprimirStatus()
	{
		Console.Clear();
		Menu.DestacarSelecao();
		Console.WriteLine("Status de " + this.Nome + '\n');
		Console.ResetColor();
		Console.WriteLine("Peças de ouro: " + this.Ouro);
		Menu.EsperarPorTecla();
	}

	public void ImprimirInventario()
	{
		Console.Clear();
		if (this.Inventario.Count == 0)
		{
			Console.WriteLine("Seu inventário está vazio.");
		}
		else
		{
			Menu.DestacarSelecao();
			Console.WriteLine("Inventário de " + this.Nome + '\n');
			Console.ResetColor();
			
			foreach (KeyValuePair<string, Tuple<Item, int>> itemDoInventario in this.Inventario)
			{
				Console.WriteLine("Nome do item: " + itemDoInventario.Key);
				Console.WriteLine("Descrição: " + itemDoInventario.Value.Item1.Descricao);
				Console.WriteLine("Quantidade: " + itemDoInventario.Value.Item2 + " unidades\n");
			}
		}
		Menu.EsperarPorTecla();
	}

	public Loja ComprarItem(string nomeDoItem, int quantidade, Loja lojaAtual)
	{
		if (lojaAtual.ItemExiste(nomeDoItem))
		{
			if (lojaAtual.RetornarQuantidadeItem(nomeDoItem) >= quantidade)
			{
				Item itemSelecionado = lojaAtual.RetornarItem(nomeDoItem);
				int valorTotal = itemSelecionado.Valor * quantidade;
				int saldoModificado = this.Ouro - valorTotal;
				if (valorTotal <= this.Ouro)
				{
					Console.Clear();
					Menu confirmacaoDeCompra = new Menu(
						"Item: " + itemSelecionado.Nome +
						"\nValor: " + itemSelecionado.Valor +
						"\nUnidades a se comprar: " + quantidade +
						"\nValor total: " + valorTotal +
						"\nSeu saldo após a compra: " + saldoModificado +
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

						this.Ouro = saldoModificado;

						Console.WriteLine("\nCompra realizada com sucesso!");
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