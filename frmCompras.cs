using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace CapaPresentacion
{
    public partial class frmCompras : Form
    {
        private Usuario _Usuario;

        public frmCompras(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;

            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboTipoDocumento.DisplayMember = "Texto";
            cboTipoDocumento.ValueMember = "Valor";
            cboTipoDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtIdProveedor.Text = "0";
            txtIdProducto.Text = "0";
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new MD_Proveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal._Proveedor.IdProveedor.ToString();
                    txtDocProveedor.Text = modal._Proveedor.Documento;
                    txtNombreProveedor.Text = modal._Proveedor.Razon;
                }
                else
                {
                    txtDocProveedor.Select();
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {

            using (var modal = new MD_Producto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._Producto.IdProducto.ToString();
                    txtCodProducto.Text = modal._Producto.Codigo;
                    txtProducto.Text = modal._Producto.Nombre;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodProducto.Select();
                }
            }
        }

        private void txtCodProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new N_Producto().Listar().Where(p => p.Codigo == txtCodProducto.Text && p.Estado == true).FirstOrDefault();

                if (oProducto != null)
                {
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtProducto.Text = oProducto.Nombre;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                }

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Debe Seleccionar un Producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal preciocompra = 0;
            decimal precioventa = 0;

            if (!decimal.TryParse(txtPrecioCompra.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out preciocompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda Incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;
            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out precioventa))
            {
                MessageBox.Show("Precio Venta - Formato moneda Incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgvData.Rows)
            {
                var idProductoCell = fila.Cells["IdProducto"].Value;
                if (idProductoCell != null && idProductoCell.ToString() == txtIdProducto.Text)
                {
                    MessageBox.Show("El producto ya existe en la lista", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            dgvData.Rows.Add(new object[]
            {
                txtIdProducto.Text,
                txtProducto.Text,
                preciocompra.ToString("0.00"),
                precioventa.ToString("0.00"),
                txtCantidad.Value.ToString(),
                (txtCantidad.Value * preciocompra).ToString("0.00")
            });

            CalcularTotal();
            LimpiarProducto();
            txtCodProducto.Select();
        }

        private void LimpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodProducto.Clear();
            txtProducto.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtCantidad.Value = 1;
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                var subtotalCellValue = row.Cells["SubTotal"].Value;

                if (subtotalCellValue != null && !string.IsNullOrEmpty(subtotalCellValue.ToString()))
                {
                    decimal subtotalValue;
                    if (decimal.TryParse(subtotalCellValue.ToString(), out subtotalValue))
                    {
                        total += subtotalValue;
                    }
                    else
                    {
                        // Manejar el caso en el que el valor no es convertible a decimal
                        // Puedes mostrar un mensaje de error o realizar otra acción apropiada
                        MessageBox.Show("Error en el formato de SubTotal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // o realiza alguna otra acción adecuada en caso de error
                    }
                }
            }

            txtTotalPagar.Text = total.ToString("0.00");
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.Icono_Eliminar20.Width;
                var h = Properties.Resources.Icono_Eliminar20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.Icono_Eliminar20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgvData.Rows.RemoveAt(indice);
                    CalcularTotal();
                }
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIdProveedor.Text) == 0)
            {
                MessageBox.Show("Debe Seleccionar un Proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe Ingresasr Productos en la Compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_compra = new DataTable();

            detalle_compra.Columns.Add("IdProducto", typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("SubTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                // Verificar si las celdas contienen valores válidos antes de convertirlos
                if (row.Cells["IdProducto"].Value != null &&
                    row.Cells["PrecioCompra"].Value != null &&
                    row.Cells["PrecioVenta"].Value != null &&
                    row.Cells["Cantidad"].Value != null &&
                    row.Cells["SubTotal"].Value != null)
                {
                    // Convertir los valores solo si no son nulos o vacíos
                    if (!string.IsNullOrEmpty(row.Cells["IdProducto"].Value.ToString()) &&
                        !string.IsNullOrEmpty(row.Cells["PrecioCompra"].Value.ToString()) &&
                        !string.IsNullOrEmpty(row.Cells["PrecioVenta"].Value.ToString()) &&
                        !string.IsNullOrEmpty(row.Cells["Cantidad"].Value.ToString()) &&
                        !string.IsNullOrEmpty(row.Cells["SubTotal"].Value.ToString()))
                    {
                        detalle_compra.Rows.Add(
                            new object[]
                            {
                    Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                    Convert.ToDecimal(row.Cells["PrecioCompra"].Value.ToString()),
                    Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString()),
                    Convert.ToInt32(row.Cells["Cantidad"].Value.ToString()),
                    Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString())
                            });
                    }
                    else
                    {
                        // Manejar el caso de valores nulos o vacíos en las celdas
                        // Puedes mostrar un mensaje de error o realizar alguna acción apropiada
                        MessageBox.Show("Uno o más valores en las celdas están vacíos o no son válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int idcorrelativo = new N_Compra().ObtenerCorrelativo();
                string numerodocumento = string.Format("{0:00000}", idcorrelativo);

                Compra oCompra = new Compra()
                {
                    objUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                    objProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtIdProveedor.Text) },
                    TipoDocumento = ((OpcionCombo)cboTipoDocumento.SelectedItem).Texto,
                    NumeroDocumento = numerodocumento,
                    MontoTotal = Convert.ToDecimal(txtTotalPagar.Text)
                };

                string mensaje = string.Empty;
                bool respuesta = new N_Compra().Registrar(oCompra, detalle_compra, out mensaje);

                if (respuesta)
                {
                    var result = MessageBox.Show("Numero de Compra generada:\n" + numerodocumento + "\n\nDesea Copiar al Portapapeles?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        Clipboard.SetText(numerodocumento);

                        txtIdProveedor.Text = "0";
                        txtDocProveedor.Clear();
                        txtNombreProveedor.Clear();
                        dgvData.Rows.Clear();
                        CalcularTotal();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
