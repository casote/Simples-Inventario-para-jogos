public abstract class Item
{
    public string Nome { get; set; }
    public double Peso { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }

    public Item(string nome, double peso, double valor)
    {
        Nome = nome;
        Peso = peso;
        Valor = valor;
        Quantidade = 1;
    }

    public abstract void Usar();
    public virtual string Descricao()
    {
        return $"Nome: {Nome}, Peso: {Peso}, Valor: {Valor}";
    }

    public class Arma : Item
    {
        public int Dano { get; set; }

        public Arma(string nome, double peso, double valor, int dano)
            : base(nome, peso, valor)
        {
            Dano = dano;
        }

        public override void Usar()
        {
            // Implementar o uso da arma
        }

        public override string Descricao()
        {
            return $"{base.Descricao()}, Dano: {Dano}";
        }
    }

    public class Armadura : Item
    {
        public int Defesa { get; set; }

        public Armadura(string nome, double peso, double valor, int defesa)
            : base(nome, peso, valor)
        {
            Defesa = defesa;
        }

        public override void Usar()
        {
            // Implementar o uso da armadura
        }

        public override string Descricao()
        {
            return $"{base.Descricao()}, Defesa: {Defesa}";
        }
    }

    public class Pocao : Item
    {
        public int Cura { get; set; }

        public Pocao(string nome, double peso, double valor, int cura)
            : base(nome, peso, valor)
        {
            Cura = cura;
        }

        public override void Usar()
        {
            // Implementar o uso da poção
        }

        public override string Descricao()
        {
            return $"{base.Descricao()}, Cura: {Cura}";
        }
    }
}
