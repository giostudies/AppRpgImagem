using AppRpgEtec.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class ImagemUsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        private static string conexaoAzureStorage = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
        private static string container = "arquivos";

        public ImagemUsuarioViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            uService = new UsuarioService(token);
        }

        private ImageSource fonteImagem;

        public ImageSource FonteImagem
        {
            get { return fonteImagem; }
            set
            {
                fonteImagem = value;
                OnPropertyChanged();
            }
        }

        public byte[] foto;

        public byte[] Foto
        {
            get => foto;
            set 
            {
                foto = value;
                OnPropertyChanged();
            }
        }

        public async void Fotografar()
        {
            try
            {

                if (MediaPicker.Default.IsCaptureSupported) {
                    FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                    if (photo != null) {
                        using (Stream sourceStream = await photo.OpenReadAsync()) {
                            using (MemoryStream ms = new MemoryStream()) {
                                await sourceStream.CopyToAsync(ms);
                                Foto = ms.ToArray();

                                FonteImagem = ImageSource.FromStream(() => new MemoryStream(ms.ToArray()));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes:" + ex.InnerException, "Ok");
            }
        }
    }
}
