using System.ComponentModel;
public class Inventario
{
    public BindingList<Item> Itens { get; set; }

    public Inventario()
    {
        Itens = new BindingList<Item>();
    }

    public void AdicionarItem(Item item)
    {
        Item itemExistente = null;
        foreach (var i in Itens)
        {
            if (i.Nome == item.Nome)
            {
                itemExistente = i;
                break;
            }
        }

        if (itemExistente != null)
        {
            itemExistente.Quantidade += item.Quantidade;
        }
        else
        {
            Itens.Add(item);
        }
    }

    public void RemoverItem(Item item)
    {
        Item itemExistente = null;
        foreach (var i in Itens)
        {
            if (i.Nome == item.Nome)
            {
                itemExistente = i;
                break;
            }
        }

        if (itemExistente != null)
        {
            itemExistente.Quantidade -= 1; // Decrease the quantity by 1
            if (itemExistente.Quantidade <= 0)
            {
                Itens.Remove(itemExistente); // Remove the item if the quantity is 0 or less
            }
        }
    }

    public void MostrarInventario()
    {
        // Implementation for showing inventory
    }
}
