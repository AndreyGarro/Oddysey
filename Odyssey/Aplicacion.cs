﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml;
using InputKey;

namespace Odyssey
{
 
    public partial class lblCalificacion : Form
    {
        private String nombreActual1;
        private String artistaActual1;
        private String ordenamientoActual;
        private byte[] musicArray = null;
        private String stdDetails = "{0, -20}{1, -15}{2, -15}{3, -15}{4, -15}";
        private String formatoAmigos = "{0, -20}{1, -40}";

        public lblCalificacion()
        {
            InitializeComponent();

        }

        private void Aplicacion_Load(object sender, EventArgs e)
        {
            panelBiblioteca.Hide();
            
        }


        private void lstCanciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¡Estás a punto de Salir! ¿Desea cerrar la aplicación?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (sideMenu.Width == 50)
            {
                sideMenu.Visible = false;
                sideMenu.Width = 200;
                miniLogo.Hide();
                panelEntra.ShowSync(sideMenu);
                logoAnimator.ShowSync(logo);

            }
            else
            {
                logoAnimator.HideSync(logo);
                sideMenu.Visible = false;
                sideMenu.Width = 50;
                panelFuera.ShowSync(sideMenu);
                miniLogo.Show();
            }
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            escondeAmigos();
            escondeNotificaciones();
            muestraBiblioteca();
            lstCanciones.Items.Clear();
            lstCanciones.Show();

            XmlDocument cargar = DocumentoXML.ordenamiento("00");
            XmlDocument lista = SocketCliente.SendServidor(cargar);

            XmlNodeList nombre = lista.GetElementsByTagName("nombre");
            XmlNodeList artista = lista.GetElementsByTagName("artista");
            XmlNodeList album = lista.GetElementsByTagName("album");
            XmlNodeList genero = lista.GetElementsByTagName("genero");
            XmlNodeList calificacion = lista.GetElementsByTagName("calificacion");

            int cont = 0;
            foreach (XmlElement i in nombre)
            {
                String nombre1 = nombre.Item(cont).InnerText;
                String artista1 = artista.Item(cont).InnerText;
                String album1 = album.Item(cont).InnerText;
                String genero1 = genero.Item(cont).InnerText;
                String calificacion1 = calificacion.Item(cont).InnerText;
                lstCanciones.Items.Add(String.Format(stdDetails, nombre1, artista1, album1, genero1, calificacion1));

                cont++;
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            //Abre la ventana de Windows para seleccionar la cancion
            OpenFileDialog abrirArchivo = new OpenFileDialog();
            abrirArchivo.Multiselect = true;
            abrirArchivo.InitialDirectory = "C:\\";
            abrirArchivo.Filter = "Music (.mp3)|*.mp3|ALL Files (*.*)|*.*";
            abrirArchivo.RestoreDirectory = true;

            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                // Lee los datos de la cancion seleccionada y los convierte en bytes y String
                musicArray = File.ReadAllBytes(abrirArchivo.FileName);
                String stringSong = Convert.ToBase64String(musicArray);

                //Solicita el nombre y artista de la cancion y lo guarda en variables
                String nombre = InputDialog.mostrar("Introduzca el nombre de la canción:");
                String artista = InputDialog.mostrar("Introduzca el artista de la canción:");

                XmlDocument song = DocumentoXML.agregaCancion(stringSong, nombre, artista);
                SocketCliente.SendServidor(song);


                /* String[] archivosMp3 = abrirArchivo.SafeFileNames;
                 String[] rutaMp3 = abrirArchivo.FileNames;
                 foreach (var archivoMp3 in archivosMp3)
                 {
                     lstCanciones.Items.Add(archivoMp3);
                 }

                 reproductor.URL = rutaMp3[0];
                 lstCanciones.SelectedIndex = 0;*/
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            lstCanciones.Items.Clear();
            ordenamientoActual = "00";
            XmlDocument ordenado = SocketCliente.SendServidor(DocumentoXML.ordenamiento("00"));

            XmlNodeList nombre = ordenado.GetElementsByTagName("nombre");
            XmlNodeList artista = ordenado.GetElementsByTagName("artista");
            XmlNodeList album = ordenado.GetElementsByTagName("album");
            XmlNodeList genero = ordenado.GetElementsByTagName("genero");
            XmlNodeList calificacion = ordenado.GetElementsByTagName("calificacion");

            int cont = 0;
            foreach (XmlElement i in nombre)
            {
                String nombre1 = nombre.Item(cont).InnerText;
                String artista1 = artista.Item(cont).InnerText;
                String album1 = album.Item(cont).InnerText;
                String genero1 = genero.Item(cont).InnerText;
                String calificacion1 = calificacion.Item(cont).InnerText;
                lstCanciones.Items.Add(String.Format(stdDetails, nombre1, artista1, album1, genero1, calificacion1));

                cont++;
            }
        }

        private void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            lstCanciones.Items.Clear();
            ordenamientoActual = "02";
            XmlDocument ordenado = SocketCliente.SendServidor(DocumentoXML.ordenamiento("02"));

            XmlNodeList nombre = ordenado.GetElementsByTagName("nombre");
            XmlNodeList artista = ordenado.GetElementsByTagName("artista");
            XmlNodeList album = ordenado.GetElementsByTagName("album");
            XmlNodeList genero = ordenado.GetElementsByTagName("genero");
            XmlNodeList calificacion = ordenado.GetElementsByTagName("calificacion");

            int cont = 0;
            foreach (XmlElement i in nombre)
            {
                String nombre1 = nombre.Item(cont).InnerText;
                String artista1 = artista.Item(cont).InnerText;
                String album1 = album.Item(cont).InnerText;
                String genero1 = genero.Item(cont).InnerText;
                String calificacion1 = calificacion.Item(cont).InnerText;
                lstCanciones.Items.Add(String.Format(stdDetails, nombre1, artista1, album1, genero1, calificacion1));

                cont++;
            }
        }

        private void lstCanciones_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click_1(object sender, EventArgs e)
        {
            lstCanciones.Items.Clear();
            ordenamientoActual = "01";
            XmlDocument ordenado = SocketCliente.SendServidor(DocumentoXML.ordenamiento("01"));

            XmlNodeList nombre = ordenado.GetElementsByTagName("nombre");
            XmlNodeList artista = ordenado.GetElementsByTagName("artista");
            XmlNodeList album = ordenado.GetElementsByTagName("album");
            XmlNodeList genero = ordenado.GetElementsByTagName("genero");
            XmlNodeList calificacion = ordenado.GetElementsByTagName("calificacion");

            int cont = 0;
            foreach (XmlElement i in nombre)
            {  
                String nombre1 = nombre.Item(cont).InnerText;
                String artista1 = artista.Item(cont).InnerText;
                String album1 = album.Item(cont).InnerText;
                String genero1 = genero.Item(cont).InnerText;
                String calificacion1 = calificacion.Item(cont).InnerText;
                lstCanciones.Items.Add(String.Format(stdDetails, nombre1, artista1, album1, genero1, calificacion1));

                cont++;
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            escondeBiblioteca();
            escondeNotificaciones();
            lstFriends.Items.Clear();
            XmlDocument solicitarLista = DocumentoXML.listaAmigos(UsuarioActual.getInstance().nombre);
            XmlDocument listaAmigos = SocketCliente.SendServidor(solicitarLista);

            XmlNodeList valor = listaAmigos.GetElementsByTagName("valor");
            String valor1 = valor[0].InnerText;
            if (valor1.Equals("true"))
            {
                XmlNodeList nombre = listaAmigos.GetElementsByTagName("nombre");
                XmlNodeList nombreUsuario = listaAmigos.GetElementsByTagName("usuario");

                int cont = 0;
                foreach (XmlElement i in nombre)
                {
                    String nombre1 = nombre.Item(cont).InnerText;
                    String nombreUsuario1 = nombreUsuario.Item(cont).InnerText;
                    lstFriends.Items.Add(String.Format(formatoAmigos, nombre1, nombreUsuario1));
                    cont++;
                }
                
            }
            else
            {
                lstFriends.Items.Add("Aún no tienes ningún amigo :c");
            }
            muestraAmigos();
        }

        private void panelAmigos_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void muestraBiblioteca()
        {
            btnRecomendar.Show();
            btnReproducir.Show();
            btnModificar.Show();
            btnDeletMusic.Show();
            panelBiblioteca.Show();
            btnNombre.Show();
            btnArtista.Show();
            btnAlbum.Show();
            btnGenero.Show();
            btnCalificacion.Show();
            lstCanciones.Show();
            btnAgregaCancion.Show();

        }

        private void escondeBiblioteca()
        {
            btnRecomendar.Hide();
            btnReproducir.Hide();
            btnModificar.Hide();
            btnDeletMusic.Hide();
            btnNombre.Hide();
            btnArtista.Hide();
            btnAlbum.Hide();
            btnGenero.Hide();
            btnCalificacion.Hide();
            lstCanciones.Hide();
            btnAgregaCancion.Hide();
        }

        private void muestraAmigos()
        {
            panelBiblioteca.Show();
            lstFriends.Show();
            txtNuevoAmigo.Show();
            btnAgregarAmigo.Show();
        }

        private void escondeAmigos()
        {
            lstFriends.Hide();
            txtNuevoAmigo.Hide();
            btnAgregarAmigo.Hide();
        }

        private void muestraNotificaciones()
        {
            txtNotificaciones.Show();
            lblNotificaciones.Show();
        }

        private void escondeNotificaciones()
        {
            txtNotificaciones.Hide();
            lblNotificaciones.Hide();
        }

        private void lstFriends_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarAmigo_Click(object sender, EventArgs e)
        {
            if (txtNuevoAmigo.Text != "")
            {
                XmlDocument nuevoAmigo = DocumentoXML.nuevoAmigo(UsuarioActual.getInstance().nombre, txtNuevoAmigo.Text);
                XmlDocument respuesta = SocketCliente.SendServidor(nuevoAmigo);
                XmlNodeList valor = respuesta.GetElementsByTagName("valor");
                if (valor[0].InnerText.Equals("true"))
                {
                    MessageBox.Show("¡Felicidades! " + txtNuevoAmigo.Text + " ha sido agregado a tus Amigos >:3", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo agregar a: " + txtNuevoAmigo.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Digite un Usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            txtNuevoAmigo.Text = "";
        }

        private void btnRecomendar_Click(object sender, EventArgs e)
        {
            lstAmigosSelección.Items.Clear();
            int cont = 0;
            if (ordenamientoActual != null)
            {
                if (lstCanciones.SelectedItem != null)
                {
                    XmlDocument listaCanciones = SocketCliente.SendServidor(DocumentoXML.ordenamiento(ordenamientoActual));
                    int index = lstCanciones.SelectedIndex;

                    XmlNodeList nodosN = listaCanciones.GetElementsByTagName("nombre");
                    XmlNodeList nodosA = listaCanciones.GetElementsByTagName("artista");

                    String nombreActual = "";
                    String artistaActual = "";
                    while (cont <= index)
                    {
                        nombreActual = nodosN.Item(cont).InnerText;
                        artistaActual = nodosA.Item(cont).InnerText;
                        cont++;
                    }

                    nombreActual1 = nombreActual;
                    artistaActual1 = artistaActual;
                    lstAmigosSeleccionTransition.ShowSync(lstAmigosSelección);
                    buttonCheckXTransition.Show(btnCheck);
                    buttonCheckXTransition.Show(btnCancel);

                    XmlDocument solicitarLista = DocumentoXML.listaAmigos(UsuarioActual.getInstance().nombre);
                    XmlDocument listaAmigos = SocketCliente.SendServidor(solicitarLista);

                    XmlNodeList valor = listaAmigos.GetElementsByTagName("valor");
                    String valor1 = valor[0].InnerText;
                    if (valor1.Equals("true"))
                    {
                        XmlNodeList nombreUsuario = listaAmigos.GetElementsByTagName("usuario");

                        cont = 0;
                        foreach (XmlElement i in nombreUsuario)
                        {
                            String nombreUsuario1 = nombreUsuario.Item(cont).InnerText;
                            lstAmigosSelección.Items.Add(nombreUsuario1);
                            cont++;
                        }
                       
                    }
                    else
                    {
                        lstFriends.Items.Add("Aún no tienes ningún amigo :c");
                    }
             
                }
                else
                {
                    MessageBox.Show("Seleccione una canción", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            String seleccion = (String)lstAmigosSelección.SelectedItem;
            lstAmigosSelección.Hide();
            btnCheck.Hide();
            btnCancel.Hide();
            SocketCliente.SendServidor(DocumentoXML.recomendar(UsuarioActual.getInstance().nombre, seleccion, nombreActual1, artistaActual1));

            MessageBox.Show("Has recomendado esta canción", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void sideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            buttonCheckXTransition.HideSync(btnCancel);
            buttonCheckXTransition.HideSync(btnCheck);
            amigosSeleccionSale.HideSync(lstAmigosSelección);

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            escondeAmigos();
            escondeBiblioteca();
            txtNotificaciones.Items.Clear();
            muestraNotificaciones();

            XmlDocument notificaciones = SocketCliente.SendServidor(DocumentoXML.notificaciones(UsuarioActual.getInstance().nombre));

            XmlNodeList valor = notificaciones.GetElementsByTagName("valor");
            if (valor[0].InnerText.Equals("true")){

                XmlNodeList notificacionesNodo = notificaciones.GetElementsByTagName("notificacion");

                int cont = 0;
                foreach (XmlElement i in notificacionesNodo)
                {
                    String notificacion = notificacionesNodo.Item(cont).InnerText;
                    txtNotificaciones.Items.Add(notificacion);
                }
            }
            else
            {
                txtNotificaciones.Items.Add("No Tienes Notificaciones");
            }
        }
    }
}
