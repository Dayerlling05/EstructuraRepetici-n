namespace pjControlRegistroParticipantes
{
    public partial class frmParticipantes : Form
    {
        int num;
        int cJefe, cOperario, cAdministrativo, cPracticante;
        public frmParticipantes()
        {
            InitializeComponent();
            tHora.Enabled = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("�ESt� seguro de sali?",
                                              "Control de registro de Participantes" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
                                           
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");

        }

        private void frmParticipantes_Load(object sender, EventArgs e)
        {
            num++;
            lblNumero.Text = num.ToString("D4");
            lblFecha.Text = DateTime.Now.ToString("d");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los datos
            DateTime fecha, hora;
            string participante, cargo;
            int numero;
            participante = txtParticipantes.Text;
            numero = int.Parse(lblNumero.Text);
            fecha = DateTime.Parse(lblFecha.Text);
            hora = DateTime.Parse(lblHora.Text);
            cargo = cboCargo.Text;

            //Contabilizar la cantidad seg�n los cargos
            switch(cargo)
            {
                case "Jefe": cJefe++; break;
                case "Operario": cOperario++; break;
                case "Administrativo":cAdministrativo++; break;
                case "Practicante":cPracticante++; break;

            }
             // Imprimiendo el registro
             ListViewItem fila = new ListViewItem(numero.ToString());
            fila.SubItems.Add(participante);
            fila.SubItems.Add(cargo);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(hora.ToString("hh:mm:ss"));
            lvParticipantes.Items.Add(fila);

            //Imprimiendo las estad�sticas
            lvEstadisticas.Items.Clear();
            string[] elementosFila = new string[2];
            ListViewItem row;

            //A�adiendo la primera fila al lvEstad�stica
            elementosFila[0] = "Jefe";
            elementosFila[1] = cJefe.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //A�adimos la segunda fila al lvEstad�stica
            elementosFila[0] = "Operario";
            elementosFila[1] = cOperario.ToString();
            row =new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //A�adimos la tercera fila al lvEstad�stica
            elementosFila[0] = "Administrativo";
            elementosFila[1] = cAdministrativo.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //A�adiendo la cuarta fila al lvEstad�stica
            elementosFila[0] = "Practicante";
            elementosFila[1]= cPracticante.ToString();
            row=new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //Mostrando el nuevo n�mero dde registro
            num++;
            lblNumero.Text = num.ToString("D4");

            //Limpiando los controles 
            txtParticipantes.Clear();
            cboCargo.SelectedIndex = -1;
            cboCargo.Text = "(Seleccione el cargo)";
            txtParticipantes.Focus();

        }
    }
}