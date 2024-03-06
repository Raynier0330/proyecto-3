using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class DetalleVenta : Form
    {
        public DetalleVenta()
        {
            InitializeComponent();
        }

        private void DetalleVenta_Load(object sender, EventArgs e)
        {
            txtBuscar.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Venta oVenta = new N_Venta().ObtenerVenta(txtBuscar.Text);

            if(oVenta.IdVenta != 0)
            {
                txtNumeroDocumento.Text = oVenta.NumeroDocumento;
                txtFecha.Text = oVenta.FechaRegistro;
                txtTipoDocumento.Text = oVenta.TipoDocumento;
                txtUsuario.Text = oVenta.objUsuario.NombreCompleto;
                txtDocCliente.Text = oVenta.DocumentoCliente;
                txtNombreCliente.Text = oVenta.NombreCliente;

                dgvData.Rows.Clear();
                foreach(Detalle_Venta dv in oVenta.objDetalleVenta)
                {
                    dgvData.Rows.Add(new object[] { dv.objProducto.Nombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal });
                }

                txtTotalPagar.Text = oVenta.MontoTotal.ToString("0.00");
                txtPago.Text = oVenta.MontoPago.ToString("0.00");
                txtCambio.Text = oVenta.MontoCambio.ToString("0.00");
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {

            txtFecha.Clear();
            txtTipoDocumento.Clear();
            txtUsuario.Clear();
            txtDocCliente.Clear();
            txtNombreCliente.Clear();
            txtNumeroDocumento.Clear();
            txtBuscar.Clear();

            dgvData.Rows.Clear();
            txtTotalPagar.Text = "0.00";
            txtPago.Text = "0.00";
            txtCambio.Text = "0.00";
        }

        private void btnDescargarExcel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("No hay Datos para Exportar!!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgvData.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Visible)
                    {
                        object[] rowData = new object[4]; // Asumiendo que estás obteniendo 4 columnas

                        for (int i = 0; i < 4; i++) // Iterar a través de las columnas específicas que necesitas
                        {
                            if (row.Cells[i].Value != null) // Verificar si la celda no es nula
                            {
                                rowData[i] = row.Cells[i].Value.ToString();
                            }
                            else
                            {
                                rowData[i] = string.Empty; // O un valor predeterminado en caso de valor nulo
                            }
                        }

                        dt.Rows.Add(rowData);
                    }
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteDetalleDeVenta_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al Generar el Reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
