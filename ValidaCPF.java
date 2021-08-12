package validacpf;

import java.util.Scanner;

public class ValidaCPF {

    public static void main(String[] args) {

        Scanner ler = new Scanner(System.in);
        
        String cpf;
        String novoCpf;
        boolean resposta = false;
        int soma = 0;
        int digito1, digito2;
        int resultado;
        int multiplicador;
        
        System.out.println("Digite um CPF: ");       
        cpf = ler.nextLine();
        cpf = cpf.replace(".", "");
        cpf = cpf.replace("-", "");
        
        if (cpf.length() != 11)
        {
            System.out.print("Erro no cpf.");
            return;
        }

        multiplicador = 10;
        for (int i = 0; i < 9; i++)
        {
            soma = soma + (Integer.parseInt(String.valueOf(cpf.charAt(i))) * multiplicador);
            multiplicador--;
        }
        
        resultado = soma % 11;

        if (resultado == 0 || resultado == 1)
            digito1 = 0;
        else 
            digito1 = 11 - resultado;

        System.out.println("Primeiro dígito: " + digito1);

        soma = 0;
        multiplicador = 11;
        for (int i = 0; i < 9; i++)
        {
            soma = soma + (Integer.parseInt(String.valueOf(cpf.charAt(i))) * multiplicador);
            multiplicador--;
        }

        soma += digito1 * 2;

        resultado = soma % 11;

        if (resultado == 0 || resultado == 1)
            digito2 = 0;
        else
        {
            digito2 = 11 - resultado;
        }

        System.out.println("Segundo dígito: " + digito2);

        if (Character.getNumericValue(cpf.charAt(9)) == (digito1) && Character.getNumericValue(cpf.charAt(10)) == (digito2))
            resposta = true;
        else
            resposta = false;
        
        System.out.println("O CPF é " + resposta);
    }
}
