using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfig)
        {
            emailConfiguracoes = emailConfig;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailConfiguracoes.UsarSSl;
                smtpClient.Host = emailConfiguracoes.ServidorSmtp;
                smtpClient.Port = emailConfiguracoes.ServidorPorta;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailConfiguracoes.Usuario, emailConfiguracoes.ServidorSmtp);

                if(emailConfiguracoes.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailConfiguracoes.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder();
                body.AppendLine("Novo Pedido")
                    .AppendLine("-----------")
                    .AppendLine("Itens");

                foreach (var item in carrinho.ItensCarrinho)
                {
                    var subtotal = item.Produto.Preco * item.Quantidade;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c})", item.Quantidade, item.Produto.Nome, subtotal);
                }

                body.AppendFormat("Valor total do pedido: {0:c}", carrinho.ObterValorTotal())
                    .AppendLine("---------------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.NomeCliente)
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? string.Empty)
                    .AppendLine(pedido.Cidade ?? string.Empty)
                    .AppendLine(pedido.Complemento ?? string.Empty)
                    .AppendLine("---------------")
                    .AppendFormat("Para presente?: {0}", pedido.EmbrulhaPresente ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(emailConfiguracoes.De, emailConfiguracoes.Para, "Novo Pedido", body.ToString());

                if(emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
