# NOMES
- **Larissa Araújo Gama-RM:964996**
- **Larissa Lopes Oliveira-RM:552628**
- **Luna Faustino Lima-RM:552473**

# 1 OBJETIVO DO PROJETO

Devido ao alto número de sinistros, que ocorrem quando há um uso excessivo ou indevido de serviços odontológicos, a OdontoPrev está enfrentando um desafio. Isso inclui consultas e tratamentos desnecessários, além de fraudes, o que resulta em aumento de custos.

Pensando nisso, propomos adicionar funções ao aplicativo da OdontoPrev, que ajudem a monitorar os hábitos de saúde bucal dos pacientes e analisar exames de Raio-X, utilizando Inteligência Artificial, para melhorar a triagem e o diagnóstico preventivo.

# 2 ESCOPO

O projeto terá como funcionalidades principais:

- **Monitoramento diário dos hábitos alimentares e de higiene bucal dos pacientes**: por meio de perguntas sobre alimentação, higiene bucal e hábitos.
- **Gamificação**: o usuário poderá ganhar pontos, que poderão ser trocados por serviços ou descontos oferecidos pela OdontoPrev.
- **Análise preditiva de Raio-X**: através do upload de exames de Raio-X, um sistema de IA fará análises automaticamente desses arquivos, com o objetivo de prever possíveis problemas dentários e identificar padrões que indiquem tratamentos desnecessários ou fraudes.

Para isso, será feita a criação de uma API REST em .NET Core para gerenciar o ciclo de vida das funcionalidades (CRUD de pacientes, dentistas, Raio-X, etc.), a implementação da lógica de negócio para o sistema de gamificação, preparação para upload de Raio-X e integração com banco de dados relacional utilizando Entity Framework Core.

# 3 REQUISITOS FUNCIONAIS

- Sistema de perguntas diárias aos pacientes para monitoramento.
- Sistema de pontuação baseado em check-ins, upload de Raio-X, informações fornecidas e outras ações.
- Upload de Raio-X e análise preditiva com base nas imagens.

# 4 REQUISITOS NÃO FUNCIONAIS

- O sistema deve ser escalável para suportar milhares de usuários simultaneamente.
- Deve garantir a segurança e a privacidade dos dados dos pacientes, com armazenamento seguro de imagens e dados pessoais.
- Alta disponibilidade para evitar interrupções no serviço.

# 5 ARQUITETURA

A solução será implementada seguindo os princípios da **Clean Architecture**, garantindo uma separação clara das responsabilidades e facilitando a escalabilidade e manutenibilidade do sistema.

- **Apresentação**: Responsável pela interface do usuário (UI) e controle das interações no aplicativo da OdontoPrev, utilizando **ASP.NET Core MVC**.
- **Aplicação**: Gerencia os casos de uso e serviços da aplicação, como o monitoramento de hábitos dos pacientes, sistema de gamificação, e a análise preditiva de exames de Raio-X, implementando as regras de negócio essenciais para o funcionamento do sistema.
- **Domínio**: Representa as principais entidades do projeto, como Paciente, Dentista, Plano, Raio-X, Análise de Raio-X, Perguntas, Respostas e Extrato de Pontos, encapsulando toda a lógica de negócio associada.
- **Infraestrutura**: Gerencia o acesso a dados, utilizando **Entity Framework Core** para integração com banco de dados **Oracle SQL**, além de outras integrações necessárias. O projeto será implementado em **.NET Core 6.0**.

