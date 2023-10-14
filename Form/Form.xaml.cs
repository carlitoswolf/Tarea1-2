using System.Text.RegularExpressions;

namespace Tarea1_2.Form;

public partial class Form : ContentPage
{
    string patron = "^[A-Za-zÁ-ÿ '-]+$";
    string patronCorreo = @"^[\w\.-]+@[\w\.-]+\.\w+$";
    string patronFecha = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\\d{4}$\n";


    public Form()
	{
		InitializeComponent();
	}

    private async void btnEnviar_Clicked(object sender, EventArgs e)
    {
        var Nombres = _nombre.Text;
        var Apellidos = _apellidos.Text;
        var Fechanac = _fechanac.Date;
        var Correo = _correo.Text;

        bool esTextoValido = Regex.IsMatch(Nombres, patron);
        bool esTextoValido2 = Regex.IsMatch(Apellidos, patron);
        bool esTextoFechaValido = Regex.IsMatch(Apellidos, patron);
        bool esCorreoValido = Regex.IsMatch(Correo, patronCorreo);

        if (esTextoValido)
        {
            if (esTextoValido2)
            {
                if (esTextoFechaValido)
                {
                    if (esCorreoValido)
                    {
                        Model.Empleado details = new Model.Empleado
                        {
                            nombres = Nombres,
                            apellidos = Apellidos,
                            fechanac = Fechanac,
                            correo = Correo
                        };

                        var instancePage = new Views.ViewPageData();
                        instancePage.BindingContext = details;
                        await Navigation.PushAsync(instancePage);
                    }
                }
            }
        }





    }
}
