using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unidad_3
{
    public partial class Form1 : Form
    {
        private int[] pila = new int[10]; // Arreglo para la pila
        private int[] cola = new int[10]; // Arreglo para la cola
        private int topePila = -1; // Inicializar el tope de la pila
        private int frenteCola = 0; // Inicializar el frente de la cola
        private int finCola = -1; // Inicializar el final de la cola
        public Form1()
        {
            InitializeComponent();
        }
        // Método para agregar un elemento a la pila
        private void PushToPila(int valor)
        {
            if (topePila < pila.Length - 1)
            {
                pila[++topePila] = valor;
            }
            else
            {
                MessageBox.Show("La pila está llena. No se puede agregar más.");
            }
        }
        // Método para quitar un elemento de la pila
        private int PopFromPila()
        {
            if (topePila >= 0)
            {
                return pila[topePila--];
            }
            else
            {
                MessageBox.Show("La pila está vacía.");
                return -1; // Valor por defecto en caso de error
            }
        }
        // Método para agregar un elemento a la cola
        private void EnqueueToCola(int valor)
        {
            if (finCola < cola.Length - 1)
            {
                cola[++finCola] = valor;
            }
            else
            {
                MessageBox.Show("La cola está llena. No se puede encolar más.");
            }
        }
        // Método para quitar un elemento de la cola
        private int DequeueFromCola()
        {
            if (frenteCola <= finCola)
            {
                return cola[frenteCola++];
            }
            else
            {
                MessageBox.Show("La cola está vacía.");
                return -1; // Valor por defecto en caso de error
            }
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(txtValor.Text);
            PushToPila(valor);
            MostrarPila();
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            int valor = PopFromPila();
            if (valor != -1)
            {
                MessageBox.Show("Elemento retirado de la pila: " + valor);
            }
            MostrarPila();
        }

        private void btnEnqueue_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(txtValor.Text);
            EnqueueToCola(valor);
            MostrarCola();
        }

        private void btnDequeue_Click(object sender, EventArgs e)
        {
            int valor = DequeueFromCola();
            if (valor != -1)
            {
                MessageBox.Show("Elemento retirado de la cola: " + valor);
            }
            MostrarCola();
        }
        private void MostrarPila()
        {
            txtPila.Text = string.Join(" -> ", pila, 0, topePila + 1);
        }
        private void MostrarCola()
        {
            txtCola.Text = string.Join(" -> ", cola, frenteCola, finCola - frenteCola + 1);
        }
    }
}
