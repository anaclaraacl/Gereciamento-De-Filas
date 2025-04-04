using ATIVIDADE_AVALIATIVA4;

class Program
{
    private static Fila filaPedido = new Fila(5);
    private static Fila filaPagamento = new Fila(5);
    private static Fila filaEntrega = new Fila(5);
    private static int id = 1;
    private static int opcao;

    private static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("Restaurante Dona Tita");
            Console.WriteLine("1 - Inserção de cliente na fila de pedidos");
            Console.WriteLine("2 - Remoção de cliente da fila de pedidos");
            Console.WriteLine("3 - Remoção de cliente da fila de pagamentos");
            Console.WriteLine("4 - Remoção de cliente da fila de encomendas");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    if (!filaPedido.cheia())
                    {
                        filaPedido.enfileirar(id);
                        Console.WriteLine($"Cliente {id} entrou na fila de pedidos.");
                        Console.WriteLine();
                        id++;
                    } else
                    {
                        Console.WriteLine("Fila de pedidos está cheia.");
                    }
                    break;

                case 2:
                    if (!filaPedido.vazia())
                    {
                        int idEmTransicao = filaPedido.desenfileirar();
                        Console.WriteLine($"Cliente {idEmTransicao} foi removido da fila de pedidos.");
                        Console.WriteLine();

                        if (!filaPagamento.cheia())
                        {
                            filaPagamento.enfileirar(id);
                            Console.WriteLine($"Cliente {idEmTransicao} entrou na fila de pagamentos.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Fila de pagamentos está cheia. Cliente não foi adicionado.");
                            Console.WriteLine();
                        }

                    } 
                    else
                    {
                        Console.WriteLine("Fila de Pedidos está vazia.");
                        Console.WriteLine();
                    }
                    break;

                case 3:
                    if (!filaPagamento.vazia())
                    {
                        int idEmTransicao = filaPagamento.desenfileirar();
                        Console.WriteLine($"Cliente {idEmTransicao} foi removido da fila de pagamentos.");
                        Console.WriteLine();
                        if (!filaEntrega.cheia())
                        {
                            filaEntrega.enfileirar(idEmTransicao);
                            Console.WriteLine($"Cliente {idEmTransicao} entrou na fila de encomendas.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Fila de encomendas está cheia. Cliente não foi adicionado.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fila de pagamentos está vazia.");
                        Console.WriteLine();
                    }
                    break;

                case 4:
                    if (!filaEntrega.vazia())
                    {
                        int idEmTransicao = filaEntrega.desenfileirar();
                        Console.WriteLine($"Cliente {idEmTransicao} foi removido da fila de encomendas.");
                        Console.WriteLine($"Cliente {idEmTransicao} recebeu sua encomenda.");
                        Console.WriteLine();
                    } else
                    {
                        Console.WriteLine("Fila de encomendas está vazia.");
                        Console.WriteLine();
                    }
                    break;

                case 5:
                    Console.WriteLine("Saindo do sistema...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    Console.WriteLine();
                    break;
            }

        } while (opcao != 5);
    }
}
