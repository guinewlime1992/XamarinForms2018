using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }
        public void BuscarCEP(object sender, EventArgs args)
        {
            //ToDo = Lógica do programa

            //ToDo = Validações
            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                { 
                Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereco: {2}, {3} - Cidade: {0}-{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O Endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro Crítico", e.Message, "OK");
                }
                }

        }
        private bool isValidCEP (string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                //ERRO
                DisplayAlert("ERRO", "CEP Inválido. O CEP deve conter 8 caracteres", "OK");

                valido = false;
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                //ERRO
                DisplayAlert("ERRO", "CEP Inválido. O CEP deve conter apenas números", "OK");

                valido = false;
            }
            return valido;
        }
    }
}
