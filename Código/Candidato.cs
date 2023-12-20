using System;

public class Candidato
{
    public string Nome { get; private set; }
    public double NotaRed { get; private set; }
    public double NotaMat { get; private set; }
    public double NotaLing { get; private set; }
    public int Op1 { get; private set; }
    public int Op2 { get; private set; }

    public Candidato(string nome, double notaRed, double notaMat, double notaLing, int op1, int op2)
    {
        Nome = nome;
        NotaRed = notaRed;
        NotaMat = notaMat;
        NotaLing = notaLing;
        Op1 = op1;
        Op2 = op2;
    }

    public double GetMedia()
    {
        return (NotaRed + NotaMat + NotaLing) / 3;
    }

    public double GetNotaRed()
    {
        return NotaRed;
    }

    public int GetOp1()
    {
        return Op1;
    }

    public int GetOp2()
    {
        return Op2;
    }

    public override string ToString()
    {
        return $"{Nome} - Média: {GetMedia():2}, Nota Redação: {NotaRed:2}";
    }
}
