using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Objetos_3D
{
    public partial class Form1 : Form
    {
        Escenario escenario;
        Dictionary<string, string> archivos;
        Vector3d vector;
        public Form1()
        {
            InitializeComponent();
            cargarArchivos();
            cargarComboObjetos();
            escenario = new Escenario();
            vector = new Vector3d(0, 0, 0);

            


        }

        public void cargarArchivos()
        {
            archivos = new Dictionary<string, string>();
            archivos.Add("Casa", "Casa.json");
            archivos.Add("Camino", "Camino.json");
        }

        public string getArchivo(string nombre)
        {
            foreach (var archivo in archivos)
            {
                if (archivo.Key == nombre)
                    return archivo.Value;
            }
            return null;
        }

        public void cargarComboObjetos()
        {
            foreach (var obj in archivos)
            {
                comboBox_add_objeto.Items.Add(obj.Key);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Game game = new Game(1000, 700, "Game", escenario);
            game.Location = new Point(x: 350, y: 0);
            game.Run();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox_add_objeto.Text))
            {
                MessageBox.Show("Selecciona un objeto!!!.");
                return;
            }

            string nombre = comboBox_add_objeto.SelectedItem.ToString();
            string archivo = getArchivo(nombre);
            escenario.agregarObjeto(nombre, archivo);

            string keyObj = escenario.getLastKey();
            comboBox_objetos.Items.Add(keyObj);
        }

        private void comboBox_objetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = comboBox_objetos.SelectedItem.ToString();
            cargarComboFaces(nombre);
        }

        public void cargarComboFaces(string nombre)
        {
            comboBox_faces.Items.Clear();
            Objeto obj = escenario.getObjeto(nombre);
            foreach (var face in obj.ListaFaces)
            {
                comboBox_faces.Items.Add(face.Key);
            }
        }

        public void rotacion()
        {
            if (checkBox_escenario.Checked)
            {
                if (radioButton_rotar.Checked)
                    rotarEscenario();
                else if (radioButton_escalar.Checked)
                    escalarEscenario();
                else if (radioButton_trasladar.Checked)
                    trasladarEscenario();
            }
                
        }

        private void trasladarEscenario()
        {
            throw new NotImplementedException();
        }

        private void escalarEscenario()
        {
            throw new NotImplementedException();
        }

        private void rotarEscenario()
        {
            escenario.rotar(float.Parse(textBox1.Text), vector);
        }

        private void button_Xs_Click(object sender, EventArgs e)
        {
            vector.X++;
        }

        private void button_Xr_Click(object sender, EventArgs e)
        {
            vector.X--;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vector.Y++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vector.Y--;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vector.Z++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vector.Z--;
        }
    }
}
