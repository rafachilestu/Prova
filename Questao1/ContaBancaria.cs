using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria {

        private double _saldo = 0;
        public double Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        private int _numeroConta = 0;
        public int NumeroConta
        {
            get { return _numeroConta; }
            set
            {
                if (_numeroConta == 0)
                {
                    _numeroConta = value;
                }
                else
                {
                    throw new InvalidOperationException("Número da conta não pode ser alterado");
                }
            }
        }

        private string _nomeTitular;
        public string NomeTitular
        {
            get { return _nomeTitular; }
            set { _nomeTitular = value; }
        }

        private double _depositoInicial = 0;
        public double DepositoInicial
        {
            get { return _depositoInicial; }
            set { _depositoInicial = value; }
        }

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            _numeroConta = numero;
            _nomeTitular = titular;
            _depositoInicial = depositoInicial;

            Deposito(_depositoInicial);            
        }

        public override string ToString()
        {
            return String.Format("Conta {0}, Titular: {1}, Cost: {2}, Saldo: $ {3}", NumeroConta, NomeTitular, DepositoInicial, Saldo.ToString("0.00", CultureInfo.InvariantCulture));
        }

        public ContaBancaria(int numero, string titular)
        {
            _numeroConta = numero;
            _nomeTitular = titular;
        }

        /// <summary>
        /// Depósito realizado na conta
        /// </summary>
        /// <param name="quantia"></param>
        internal void Deposito(double quantia)
        {
            _saldo += quantia;
        }

        /// <summary>
        /// Para cada saque realizado, a instituição cobra uma taxa de $ 3.50
        /// </summary>
        /// <param name="quantia"></param>
        internal void Saque(double quantia)
        {
            _saldo -= quantia - 3.50;
        }
    }
}
