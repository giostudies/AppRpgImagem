using AppRpgEtec.ViewModels.Usuarios;

namespace AppRpgEtec.Views.Usuarios;

public partial class ImagemUsuarioView : ContentPage
{
    ImagemUsuarioViewModel viewModel;

    public ImagemUsuarioView()
    {
        InitializeComponent();

        viewModel = new ImagemUsuarioViewModel();
        Title = "Imagem do Usu�rio";
        BindingContext = viewModel;



    }
}