using System;
using System.Collections;
namespace Banco
{
    class Program
    {
        static int option;
        static ArrayList cuentas = new ArrayList();
        static void Main(string[] args)
        {
            string nombre;
            string account_number;
            string account_type = "";
            string account_password;
            float balance;
            Random r = new Random();

            do
            {
                Console.WriteLine("Hola, bienvenid@ al surcunsal bancario SHED");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("Ingrese el numero 1 para crear una nueva cuenta bancaria");
                Console.WriteLine(" ");
                Console.WriteLine("ingrese el numero 2 para ver la informacion de una cuenta ya existente");
                Console.WriteLine(" ");
                Console.WriteLine("Ingrese el numero 3 para realizar un retiro");
                Console.WriteLine(" ");
                Console.WriteLine("Ingrese el numero 4 para cambiar su password");
                Console.WriteLine(" ");
                Console.WriteLine("Ingrese el numero 5 para realizar una transferencia");
                Console.WriteLine(" ");
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    int tip_cuenta;
                    Console.WriteLine("Muchas gracias por escoger nuestra surcunsal. Porfavor proceda a escibir su nombre completo");
                    nombre = Console.ReadLine();
                    Console.WriteLine(" ");
                    Console.WriteLine("Muy bien, ahora seleccione su tipo de cuenta");
                    Console.WriteLine(" ");
                    Console.WriteLine("1. Ahorros");
                    Console.WriteLine("2. Corriente");
                    Console.WriteLine(" ");
                    tip_cuenta = int.Parse(Console.ReadLine());

                    if (tip_cuenta == 1 && tip_cuenta != 0)
                    {
                        account_type = "Ahorros";
                    }
                    else if (tip_cuenta == 2 && tip_cuenta != 0)
                    {
                        account_type = "Corriente";
                    }

                    else
                    {
                        Console.WriteLine("La opcion ingresada no es valida, por favor empiece de nuevo");
                    }

                    Console.WriteLine(" ");
                    Console.WriteLine("Ya casi finalizamos; por favor ingrese una clave de cuatro digitos para su cuenta ");
                    account_password = (Console.ReadLine());


                    Console.WriteLine(" ");
                    Console.WriteLine(" Por ultimo, por favor ingrese una cantidad inicial para depositar en su cuenta");
                    balance = float.Parse(Console.ReadLine());
                    int number = r.Next(0, 9999999);
                    account_number = number.ToString();

                    Console.WriteLine(" ");
                    Console.WriteLine("Bien, ya acabamos, el numero de su cuenta es: ");
                    Console.WriteLine(account_number);

                    Console.WriteLine(" ");
                    Console.WriteLine(" Muchas gracias por escogernos como entidad bancaria, desde ahora podra consultar los detalles de su cuenta en cualquiera de nuestras surcunsales");
                    Cuenta cs = new Cuenta(nombre, account_type, account_number, account_password, balance);
                    cuentas.Add(cs);
                    Console.WriteLine(" ");
                }


                if (option == 2)
                {
                    string num;
                    Console.WriteLine("POR FAVOR INGRESE EL NUMERO DE LA CUENTA PARA VER LA INFORMACION");
                    num = Console.ReadLine();

                    foreach (Cuenta c in cuentas)
                    {
                        if (num.Equals(c.getnumero_cuenta()))
                        {
                            Console.WriteLine(c.getInformacion_cuenta(num));
                            Console.WriteLine(" ");
                        }
                        else
                        {
                            Console.WriteLine("La cuenta no existe, por favor intente de nuevo");
                            Console.WriteLine(" ");
                        }
                    }
                }

                if (option == 3)
                {
                    string num;
                    string clave;
                    float cant;
                    Console.WriteLine("POR FAVOR INGRESE EL NUMERO DE LA CUENTA DEL CUAL QUIERE HACER EL RETIRO");
                    num = Console.ReadLine();

                    foreach (Cuenta c in cuentas)
                    {
                        if (num.Equals(c.getnumero_cuenta()))
                        {
                            Console.WriteLine("Bien, la cuenta ya ha sido verificada, por favor ingrese la clave");
                            clave = Console.ReadLine();
                            Console.WriteLine(" ");

                            if (clave.Equals(c.getClave_cuenta()))
                            {
                                Console.WriteLine("Vale, la clave coincide con el numero de su cuenta. Ahora por favor ingrese la cantidad a retirar");
                                cant = float.Parse(Console.ReadLine());
                                Console.WriteLine(" ");

                                if (c.getSaldo() >= cant)
                                {
                                    c.retiro(cant);
                                    Console.WriteLine("el retiro fue satisfactorio, su nuevo saldo es: " + c.getSaldo());
                                    Console.WriteLine(" ");
                                }
                                else
                                {
                                    Console.WriteLine("Usted no posee saldo suficiente para realizar este retiro!");
                                }
                            }
                        }

                        else
                        {
                            Console.WriteLine("La cuenta no existe, por favor intente de nuevo");
                            Console.WriteLine(" ");
                        }
                    }
                }

                if (option == 4)
                {
                    string num;
                    Console.WriteLine("POR FAVOR INGRESE EL NUMERO DE LA CUENTA DEL CUAL QUIERE CAMBIAR LA CLAVE");
                    num = Console.ReadLine();
                    string clave;
                    string nueva_clave;

                    foreach (Cuenta c in cuentas)
                    {
                        if (num.Equals(c.getnumero_cuenta()))
                        {
                            Console.WriteLine("Bien, la cuenta ya ha sido verificada, por favor ingrese la clave");
                            clave = Console.ReadLine();
                            Console.WriteLine(" ");

                            if (clave.Equals(c.getClave_cuenta()))
                            {
                                Console.WriteLine("Vale, la clave coincide con el numero de su cuenta. Ahora por favor ingrese la nueva clave (DE CUATRO DIGITOS) para asignarle a su cuenta");
                                nueva_clave = Console.ReadLine();

                                if (nueva_clave.Length == 4)
                                {
                                    c.cambiar_clave(nueva_clave);
                                }
                                else
                                {
                                    Console.WriteLine("Lo sentimos, la clave no cumple con los requisitos");
                                }
                            }
                            else
                            {
                                Console.WriteLine("La cuenta no existe, por favor intente de nuevo");
                                Console.WriteLine(" ");
                            }
                        }
                    }
                }

                if (option == 5)
                {
                    string num;
                    String num2;
                    float valor;
                    string clav;
                    Console.WriteLine("Por favor ingrese el numero de su cuenta");
                    num = Console.ReadLine();

                    if (verificar_Cuenta(num) == true)
                    {
                        Console.WriteLine("Cuenta verificada. por favor ingrese la clave");
                        clav = Console.ReadLine();

                        if (verificar_clave(num, clav) == true)
                        {
                            Console.WriteLine("la clave ingresada coincide con la cuenta. Ahora, por favor ingrese el numero de la cuenta a la cual desea transferir");
                            num2 = Console.ReadLine();

                            if (verificar_Cuenta(num2) == true)
                            {
                                Console.WriteLine("La cuenta fue verficada. Por ultimo, ingrese el valor a transferir");
                                valor = float.Parse(Console.ReadLine());

                                transferencia(num, num2, valor);
                            }
                            else
                            {
                                Console.WriteLine("La cuenta receptora no existe.");
                            }

                        }
                        else
                        {
                            Console.WriteLine("La clave ingresada esta erronea.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La cuenta ingresada no existe.");
                    }
                }
            }
            while (option != 0) ;
        }
        static bool verificar_Cuenta(string num)
        {
            bool encontrado = false;

            foreach (Cuenta cs in cuentas)
            {
                if (num.Equals(cs.getnumero_cuenta()))
                {
                    encontrado = true;
                }
            }
            return encontrado;
        }

        static bool verificar_clave(string numCuenta, string clave)
        {
            bool encontrado = false;

            foreach (Cuenta cs in cuentas)
            {
                if (numCuenta.Equals(cs.getnumero_cuenta()) && clave.Equals(cs.getClave_cuenta()))
                {
                    encontrado = true;
                }
            }
            return encontrado;

        }

        static void transferencia(string num1, string num2, float valor)
        {
            float sald = 0;
            foreach (Cuenta cs in cuentas)
            {
                if (num1.Equals(cs.getnumero_cuenta()) && cs.getSaldo() > valor)
                {
                    sald = cs.getSaldo();
                    cs.transferir(valor);
                    Console.WriteLine("Transaccion exitosa. Su nuevo saldo es: " + cs.getSaldo());
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("Lo sentimos, pero usted no tiene saldo suficiente para completar esta transaccion");
                    Console.WriteLine(" ");
                }

                if (num2.Equals(cs.getnumero_cuenta()) && sald > valor)
                {
                    cs.Recibir_transaccion(valor);
                    Console.WriteLine("El nuevo saldo de la cuenta receptora es: " + cs.getSaldo());
                    Console.WriteLine(" ");
                }

              
            }
        }
        

    }
}
            
    
            