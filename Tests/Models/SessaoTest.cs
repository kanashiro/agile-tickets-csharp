using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using AgileTickets.Web.Models;

namespace Tests.Models
{
    [TestFixture]
    public class SessaoTest
    {
        [Test]
        public void DeveVender1IngressoSeHa2Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 2;

            Assert.IsTrue(sessao.PodeReservar(1));
        }

        [Test]
        public void NaodeveVender3IngressoSeHa2Vagas()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 2;

            Assert.IsFalse(sessao.PodeReservar(3));
        }

        [Test]
        public void ReservarIngressosDeveDiminuirONumeroDeIngressosDisponiveis()
        {
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 5;

            sessao.Reserva(3);
            Assert.AreEqual(2, sessao.IngressosDisponiveis);
        }

        [Test]
        public void DeveReservar1IngressoSeHa1Vaga()
        {
            // ARRANGE
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 1;

            // ACT
            bool result = sessao.PodeReservar(1);

            // ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void DeveReservar100IngressoSeHa100Vaga()
        {
            // ARRANGE
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 100;

            // ACT
            bool result = sessao.PodeReservar(100);

            // ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void DeveReservar10IngressoSeHa10Vaga()
        {
            // ARRANGE
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 10;

            // ACT
            bool result = sessao.PodeReservar(10);

            // ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void DeveReservar10IngressoSeHa100Vaga()
        {
            // ARRANGE
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 100;

            // ACT
            bool result = sessao.PodeReservar(10);

            // ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void DeveReservar1IngressoSeHa10Vaga()
        {
            // ARRANGE
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 10;

            // ACT
            bool result = sessao.PodeReservar(1);

            // ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void NaoDeveReservar10IngressoSeHa1Vaga()
        {
            // ARRANGE
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 1;

            // ACT
            bool result = sessao.PodeReservar(10);

            // ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void NaoDeveReservar500IngressoSeHa100Vaga()
        {
            // ARRANGE
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 100;

            // ACT
            bool result = sessao.PodeReservar(500);

            // ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void NaoDeveReservarQuantidadeDeIngressosNegativo()
        {
            // ARRANGE
            Sessao sessao = new Sessao();
            sessao.TotalDeIngressos = 1;

            // ACT
            bool result = sessao.PodeReservar(-1);

            // ASSERT
            Assert.IsFalse(result);
        }
    }
}
