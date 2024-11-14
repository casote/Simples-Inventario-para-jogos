🛠️ Sistema de Inventário - Gerenciamento de Itens no Jogo 🎒  
  
Este é um sistema de inventário simples desenvolvido em C# usando Windows Forms (.NET Framework). O objetivo do projeto é permitir o gerenciamento de itens, onde o jogador pode adicionar, remover e usar objetos como armas, poções e armaduras.  

  
📙 Sobre o Projeto  
O sistema de inventário foi criado como uma ferramenta para ensinar e demonstrar conceitos de gerenciamento de itens em jogos, além de servir como base para a criação de sistemas mais complexos. Cada item possui atributos específicos, como peso, valor e funcionalidades únicas. A interface gráfica foi desenhada para simplificar a interação e facilitar o uso de inventários em jogos de RPG e ação.  
  
  
🎮 Como Usar o Sistema  
Adicionar Itens: Clique no botão “Adicionar Item” para inserir automaticamente um conjunto de itens predefinidos (ex.: espada, poção e armadura).  
Remover Itens: Selecione um item na lista e clique em “Remover Item” para excluí-lo do inventário.  
Usar Itens: Clique em “Usar Item” após selecionar um item para visualizar uma mensagem simulando o efeito de seu uso.  
  
  
🚀 Configuração e Execução  
Baixe o projeto clicando em "Code" > "Download ZIP".  
  
ou  
  
Clone o repositório:  
    
````
bash
Copy code
git clone https://github.com/casote/Simples-Inventario-para-jogos.git

````
  
Abra o projeto no Visual Studio, compile e execute o projeto.  
📝 Estrutura do Projeto  
python  
Copy code  
📂 InventarioDeItens   
├── bin  
│-----└── Debug  
│------------└── InventarioDeJogos.exe    # Arquivo executável  
├── obj  
│----└── Debug  
├── InventarioDeJogos.csproj         # Arquivo de projeto  
├── Program.cs                       # Código principal  
├── Form1.cs                         # Formulário principal com a interface do inventário  
├── Inventario.cs                    # Classe de gerenciamento do inventário  
└── Item.cs, Arma.cs, Pocao.cs       # Classes dos tipos de itens  
  
📝 Requisitos  
.NET Framework (compatível com Windows Forms)  
Visual Studio (recomendado para desenvolvimento e execução)  

🛠️ Tecnologias Utilizadas  
C# - Linguagem de programação  
Windows Forms (.NET Framework) - Biblioteca para interface gráfica  
  
💡 Funcionalidades  
Interface gráfica intuitiva para fácil gerenciamento de inventário.  
Sistema para adicionar, remover e usar diferentes itens com atributos únicos.  
  
🔮 Melhorias Futuras 📈  
Adicionar sons para feedback ao usar ou remover itens.  
Implementar categorias de itens para organizar o inventário.  
Adicionar uma visualização de detalhes dos itens ao serem selecionados.  
Criar uma barra de pesquisa para localizar rapidamente itens no inventário.  
  
📄 Licença  
Este projeto está licenciado sob a licença MIT. Consulte o arquivo [LICENSE](https://github.com/casote/Simples-Inventario-para-jogos/blob/main/LICENSE.txt) para mais detalhes.
