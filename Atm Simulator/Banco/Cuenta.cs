using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    class Cuenta
    {
        private string titular;
        private string tipo;
        private string num_cuenta;
        private string clave;
        private float saldo;
        private float valorTransf;

        public Cuenta(string titular, string tipo, string num_cuenta, string clave, float saldo)
        {
            this.titular = titular;
            this.tipo = tipo;
            this.num_cuenta = num_cuenta;
            this.clave = clave;
            this.saldo = saldo;
        }
        public float getSaldo()
        {
            return saldo;
        }

        public void cambiar_clave(string nueva_clave)
        {
            clave = nueva_clave;
        }

        public void retiro(float cantidad)
        {
            saldo -= cantidad;
        }

        public void transferir (float valor_transferencia)
        {
            valorTransf = valor_transferencia;
            saldo -= valor_transferencia;
        }

        public void Recibir_transaccion(float valor_transferencia)
        {
            saldo += valor_transferencia;
             valorTransf= 0;
        }

        public string getInformacion_cuenta(string num_cuenta)
        {
            return ("El titular de esta cuenta se llama " + titular + " --- El tipo de cuenta es: " + tipo + " --- El número de su cuenta es: " + num_cuenta + " --- la clave de su cuenta es: " + clave + " --- Su saldo es: " + saldo);

        }

        public string getnumero_cuenta()
        {
            return num_cuenta;
        }

        public string getClave_cuenta()
        {
            return clave;
        }

       
        
    }
}
