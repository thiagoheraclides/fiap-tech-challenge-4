using Br.Com.Fiap.Api.DTO;

namespace Br.Com.Fiap.Tests
{
    public class PerfilInvestidorTeste
    {
        [Fact]
        public void SucessoValidacaoDoModelo()
        {
            //ARRANGE
            var perfilInvestidorDTO = new PerfilInvestidorDTO
            {
                Codigo = default,
                Nome = "Kamikaze",
                Descricao = "Investidor alucinado.",
                Ativo = true,
                DataRegistro = DateTime.Now
            };

            //ACT
            var errors = ModelValidator.Validate(perfilInvestidorDTO);

            //ASSERT
            Assert.Equal(0, errors.Count);
        }

        [Fact]
        public void ErroParaNomeNulo()
        {
            //ARRANGE
            var perfilInvestidorDTO = new PerfilInvestidorDTO
            {
                Codigo = default,
                Nome = string.Empty,
                Descricao = "Investidor alucinado.",
                Ativo = true,
                DataRegistro = DateTime.Now
            };

            //ACT
            var errors = ModelValidator.Validate(perfilInvestidorDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Nome") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaDescricaoNulo()
        {
            //ARRANGE
            var perfilInvestidorDTO = new PerfilInvestidorDTO
            {
                Codigo = default,
                Nome = "Kamikaze",
                Descricao = string.Empty,
                Ativo = true,
                DataRegistro = DateTime.Now
            };

            //ACT
            var errors = ModelValidator.Validate(perfilInvestidorDTO);

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Descricao") && e.ErrorMessage.Contains("obrigatório"));
        }

        [Fact]
        public void ErroParaSituacaoInvalida()
        {
            //ARRANGE
            var perfilInvestidorDTO = new PerfilInvestidorDTO
            {
                Codigo = default,
                Nome = "Kamikaze",
                Descricao = "Investidor alucinado.",
                Ativo = false,
                DataRegistro = DateTime.Now
            };

            //ACT
            var errors = ModelValidator.Validate(perfilInvestidorDTO);           

            //ASSERT
            Assert.True(errors.Any());
            Assert.Contains(errors, e => e.MemberNames.Contains("Ativo") && e.ErrorMessage.Contains("valor válido"));
        }

        [Fact]
        public void ErroParaNomeTamanhoMinimo()
        {
            //ARRANGE
            var perfilInvestidorDTO = new PerfilInvestidorDTO
            {
                Codigo = default,
                Nome = "K",
                Descricao = "Investidor alucinado.",
                Ativo = true,
                DataRegistro = DateTime.Now
            };

            //ACT
            var errors = ModelValidator.Validate(perfilInvestidorDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("Nome") && e.ErrorMessage.Contains("mínimo de 2 e máximo de 20 caracteres"));
        }

        [Fact]
        public void ErroParaNomeTamanhoMaximo()
        {
            //ARRANGE
            var perfilInvestidorDTO = new PerfilInvestidorDTO
            {
                Codigo = default,
                Nome = "KamikazeKamikazeKamikazeKamikazeKamikaze",
                Descricao = "Investidor alucinado.",
                Ativo = true,
                DataRegistro = DateTime.Now
            };

            //ACT
            var errors = ModelValidator.Validate(perfilInvestidorDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("Nome") && e.ErrorMessage.Contains("mínimo de 2 e máximo de 20 caracteres"));
        }

        [Fact]
        public void ErroParaDescricaoTamanhoMinimo()
        {
            //ARRANGE
            var perfilInvestidorDTO = new PerfilInvestidorDTO
            {
                Codigo = default,
                Nome = "Kamikaze",
                Descricao = "I",
                Ativo = true,
                DataRegistro = DateTime.Now
            };

            //ACT
            var errors = ModelValidator.Validate(perfilInvestidorDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("Descricao") && e.ErrorMessage.Contains("mínimo de 2 e máximo de 200 caracteres"));
        }

        [Fact]
        public void ErroParaDescricaoTamanhoMaximo()
        {
            //ARRANGE
            var perfilInvestidorDTO = new PerfilInvestidorDTO
            {
                Codigo = default,
                Nome = "Kamikaze",
                Descricao = "Lorem ipsum dolor sit amet. Ex possimus omnis et voluptate repellat et laudantium repudiandae id Quis maxime" +
                " quo aliquam autem sed consequuntur quaerat? Ut tempore molestiae et similique quas At unde atque et voluptatum dolore" +
                " id quia quisquam id velit voluptas. Ut corporis dolore ut unde quia sit sequi voluptatem et odit accusamus? Qui nemo" +
                " consequuntur eum nihil reiciendis qui dolorem beatae. Sit possimus internos a quaerat tempore aut voluptate impedit qui" +
                " debitis error ab reprehenderit necessitatibus aut dolorem eius. Ad provident velit id officia suscipit ut perspiciatis" +
                " mollitia ex tenetur error in itaque esse. Ab voluptatem quis eos eius officiis aut velit internos in atque quia ab " +
                "voluptatem harum aut quod perspiciatis hic voluptatem autem. Cum praesentium dolor aut commodi molestiae At vero aliquam",
                Ativo = true,
                DataRegistro = DateTime.Now
            };

            //ACT
            var errors = ModelValidator.Validate(perfilInvestidorDTO);

            //ASSERT
            Assert.Single(errors);
            Assert.Contains(errors, e => e.MemberNames.Contains("Descricao") && e.ErrorMessage.Contains("mínimo de 2 e máximo de 200 caracteres"));
        }
    }
}
