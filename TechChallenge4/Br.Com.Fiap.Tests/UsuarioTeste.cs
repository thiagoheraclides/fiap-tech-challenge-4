using Br.Com.Fiap.Api.DTO;

namespace Br.Com.Fiap.Tests
{
    public class UsuarioTeste
    {
        [Fact]
        public void SucessoValidacaoDoModelo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Equal(0, errors.Count);
        }

        [Fact]
        public void ErroParaCampoRequiridoCPF()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
 
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("CPF") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaCampoRequiridoNome()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {

                CPF = "42509631012",               
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Nome") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaCampoRequiridoEmail()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Email") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaCampoRequiridoLogin()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",               
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Login") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaCampoRequiridoSenha() 
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Senha") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaCampoRequiridoTipoUsuarioCodigo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("TipoUsuarioCodigo") && e.ErrorMessage.Contains("valor válido"));
        }

        [Fact]
        public void ErroParaCPFNulo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = string.Empty,
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("CPF") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaNomeNulo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = string.Empty,
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Nome") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaEmailNulo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = string.Empty,
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Email") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaLoginNulo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = string.Empty,
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Login") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaSenhaNulo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = string.Empty,
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Senha") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaCpfTamanhoMinimo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "4250963101",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("CPF") && e.ErrorMessage.Contains("Preenchimento obrigatório de 11 caracteres"));
        }

        [Fact]
        public void ErroParaCpfTamanhoMaximo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "425096310123",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("CPF") && e.ErrorMessage.Contains("Preenchimento obrigatório de 11 caracteres"));
        }

        [Fact]
        public void ErroParaNomeTamanhoMinimo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "G",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("Nome") && e.ErrorMessage.Contains("mínimo de 2 e máximo de 100 caracteres"));
        }

        [Fact]
        public void ErroParaNomeTamanhoMaximo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana Gesner Zarabatana Gesner Zarabatana Gesner Zarabatana Gesner Zarabatana Gesner Zarabatana Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("Nome") && e.ErrorMessage.Contains("mínimo de 2 e máximo de 100 caracteres"));
        }

        [Fact]
        public void ErroParaEmailTamanhoMinimo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "g",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Equal(2, errors.Count());
            Assert.Contains(errors, e => e.MemberNames.Contains("Email") && e.ErrorMessage.Contains("mínimo de 10 e máximo de 100 caracteres"));
            Assert.Contains(errors, e => e.MemberNames.Contains("Email") && e.ErrorMessage.Contains("mínimo de 10 e máximo de 100 caracteres"));
        }

        [Fact]
        public void ErroParaEmailTamanhoMaximo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.brgesner.zarabata@mail.com.brgesner.zarabata@mail.com.brgesner.zarabata@mail.com.brgesner.zarabata@mail.com.brgesner.zarabata@mail.com.brgesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Equal(2, errors.Count());
            Assert.Contains(errors, e => e.MemberNames.Contains("Email") && e.ErrorMessage.Contains("mínimo de 10 e máximo de 100 caracteres"));
            Assert.Contains(errors, e => e.MemberNames.Contains("Email") && e.ErrorMessage.Contains("mínimo de 10 e máximo de 100 caracteres"));
        }

        [Fact]
        public void ErroParaLoginTamanhoMinimo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "g",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("Login") && e.ErrorMessage.Contains("mínimo de 2 e máximo de 50 caracteres"));
        }

        [Fact]
        public void ErroParaLoginTamanhoMaximo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana.gesner.zarabatana.gesner.zarabatana.gesner.zarabatana.gesner.zarabatana",
                Senha = "123456",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("Login") && e.ErrorMessage.Contains("mínimo de 2 e máximo de 50 caracteres"));
        }

        [Fact]
        public void ErroParaSenhaTamanhoMinimo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "1234",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("Senha") && e.ErrorMessage.Contains("mínimo de 5 e máximo de 50 caracteres"));
        }

        [Fact]
        public void ErroParaSenhaTamanhoMaximo()
        {
            //ARRANGE
            var usuarioDTO = new UsuarioDTO
            {
                CPF = "42509631012",
                Nome = "Gesner Zarabatana",
                Email = "gesner.zarabata@mail.com.br",
                Login = "gesner.zarabatana",
                Senha = "1234567890123456789012345678901234567890123456789012345678901234567890",
                TipoUsuarioCodigo = 1,
                PerfilCodigo = default,
                Endereco = new EnderecoDTO
                {
                    Cep = "09271020",
                    Logradouro = "Rua Liguaria",
                    Numero = "215",
                    Complemento = "Casa 1",
                    Bairro = "Parque Novo Oratório",
                    Cidade = "Santo André",
                    Estado = "São Paulo"
                }
            };

            //ACT
            var errors = ModelValidator.Validate(usuarioDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("Senha") && e.ErrorMessage.Contains("mínimo de 5 e máximo de 50 caracteres"));

        }
    }
}
