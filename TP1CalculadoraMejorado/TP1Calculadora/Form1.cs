using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1Calculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double auxResultado;
            
            Numero number1 = new Numero(txtNumero1.Text);
            Numero number2 = new Numero(txtNumero2.Text);
            
            auxResultado = Calculadora.operar(number1, number2, Calculadora.validarOperador(cmbOperacion.Text)); //Si no se selecciona operador, el metodo validarOperador devuelve un + y realiza la operación con dicho operador.
            cmbOperacion.Text = Calculadora.validarOperador(cmbOperacion.Text); //Coloca en el texto del cmb el operador actual que se está utilizando.
            lblResultado.Text = auxResultado.ToString();
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperacion.Text = "";
        }
    }
}
