using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolExpresionesAritmeticas
{
    public partial class Form1 : Form
    {
        private Nodo raiz;
        private Arbol arbol;
        Grafico grafico;
        public Form1()
        {
            InitializeComponent();
            arbol = new Arbol();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if(txtExpresion.Text != "")
            {
                arbol.InsertarEnCola(txtExpresion.Text);
                raiz = arbol.CrearArbol();
                arbol.Limpiar();
                //preorden
                //inorden
                //postorden
                grafico = new Grafico(arbol.nodoDot);
                grafico.DrawTree();
                ShowTree();
            }
            else
            {
                MessageBox.Show("Debes ingresar una expresion aritmetica", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowTree()
        {
            if (File.Exists(@"C:\Users\sonia\Imagen.png"))
            {
                using (FileStream img = new FileStream(@"C:\Users\sonia\Imagen.png", FileMode.Open, FileAccess.Read))
                {
                    pbImagen.Image = Bitmap.FromStream(img);
                }
            }
            else
            {
                MessageBox.Show("No se ha podido abrir el archivo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pbImagen.Refresh();
        }
    }
}
