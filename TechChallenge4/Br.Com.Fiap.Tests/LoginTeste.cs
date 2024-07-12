using Br.Com.Fiap.Api.DTO;
using System.ComponentModel.DataAnnotations;

namespace Br.Com.Fiap.Tests
{
    public class LoginTeste
    {
        [Fact]
        public void ErroParaCampoRequiridoLogin()
        {
            //ARRANGE
            var loginDTO = new LoginDTO
            {
                Senha = "123456"
            };

            //ACT
            var errors = ModelValidator.Validate(loginDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Login") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaCampoRequiridoSenha()
        {
            //ARRANGE
            var loginDTO = new LoginDTO
            {
                Login = "gesner.zarabatana"
            };

            //ACT
            var errors = ModelValidator.Validate(loginDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Senha") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaTamanhoMinimoCampoLogin()
        {
            //ARRANGE
            var loginDTO = new LoginDTO
            {
                Login = "g",
                Senha = "123456"
            };

            //ACT
            var errors = ModelValidator.Validate(loginDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Login") && e.ErrorMessage.Contains("Preenchimento obrigatório mínimo de 2"));
        }

        [Fact]
        public void ErroParaTamanhoMaximoCampoLogin()
        {
            //ARRANGE
            var loginDTO = new LoginDTO
            {
                Login = "gesner.zarabatana.gesner.zarabatana.gesner.zarabatana",
                Senha = "123456"
            };

            //ACT
            var errors = ModelValidator.Validate(loginDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Login") && e.ErrorMessage.Contains("máximo de 50 caracteres"));
        }

        [Fact]
        public void ErroParaTamanhoMinimoCampoSenha()
        {
            //ARRANGE
            var loginDTO = new LoginDTO
            {
                Login = "gesner.zarabatana",
                Senha = "123"
            };

            //ACT
            var errors = ModelValidator.Validate(loginDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Senha") && e.ErrorMessage.Contains("Preenchimento obrigatório mínimo de 5"));
        }

        [Fact]
        public void ErroParaTamanhoMaximoCampoSenha()
        {
            //ARRANGE
            var loginDTO = new LoginDTO
            {
                Login = "gesner.zarabatana.gesner.zarabatana.gesner.zarabatana",
                Senha = "1234565678901234565678901234565678901234565678901234565678901"
            };

            //ACT
            var errors = ModelValidator.Validate(loginDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Senha") && e.ErrorMessage.Contains("máximo de 50 caracteres"));
        }


        [Fact]
        public void SucessoParaPreenchimentoCorreto()
        {
            //ARRANGE
            var loginDTO = new LoginDTO
            {
                Login = "gesner.zarabatana",
                Senha = "123456"
            };

            //ACT
            var errors = ModelValidator.Validate(loginDTO);

            //ASSERT
            Assert.Equal(0, errors.Count);
        }
    }
}
