using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATIVIDADE_AVALIATIVA4
{
    class Fila
    {
        private int[] vet;
        private int inicio = 0;
        private int fim = 0;

        public Fila(int tamanho)
        {
            vet = new int[tamanho + 1];
        }

        public bool vazia()
        {
            return inicio == fim;
        }

        public bool cheia()
        {
            return (fim + 1) % vet.Length == inicio;
        }

        public void enfileirar(int item)
        {
            if (!cheia())
            {
                vet[fim] = item;
                fim = (fim + 1) % vet.Length;
            }
        }

        public int desenfileirar()
        {
            if (!vazia())
            {
                int item = vet[inicio];
                inicio = (inicio + 1) % vet.Length;
                return item;
            }
            return 0;
        }

        public void imprimir()
        {
            string valores = "";
            for (int i = inicio; i != fim; i = (i + 1) % vet.Length)
            {
                valores += vet[i] + ", ";
            }
            Console.WriteLine("[ {0} ]",
                valores.Length > 0 ?
                valores.Substring(0, valores.Length - 2) :
                valores
            );
        }
    }
}
