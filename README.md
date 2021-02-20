## Mark Equips - Reserva de Equipamentos
[![Build Status](https://travis-ci.com/AllisonSBahls/mark-equips.svg?branch=main)](https://travis-ci.com/AllisonSBahls/mark-equips)

### :blush: **Projeto**

  O Mark Equips é um sistema de reserva de equipamentos e laboratorios, desenvolvido com o objetivos de estudos, colando em prática os conhecimentos em Web API Restful utilizando C#, Asp.Net 5, abordando todos os níveis de maturidade definidos por Leonard Richardson. E para consumir a API foi criado um front end utilizando React com Typescript.
  Apesar de ser uma aplicação voltada para estudos a ideia surgiu de um problema encontrado no local de trabalho em que para reservar equipamentos e laboratórios é feito de maneira manual usando uma planilha impressa, sendo necessário entrar em contato com o responsável para verificar a disponibilidade do item, dessa forma o sistema já defini quais equipamentos estão disponiveis e os horários que é possivel reserva-los.

<p align="center">Painel do Administrador</p>
<p align="center">
    <a href="https://i.imgur.com/QIVucI4.jpg">
    <img src="https://i.imgur.com/QIVucI4.jpg" alt="Página com as reservas para hoje" height="200">
  </a>
   <a href="https://i.imgur.com/HybLaUB.jpg">
    <img src="https://i.imgur.com/HybLaUB.jpg" alt="Equipamentos para reservar" height="215">
  </a>
</p>

<p align="center">Painel do Colaborador</p>
<p align="center">
   <a href="https://i.imgur.com/gcNFFlk.jpg">
    <img src="https://i.imgur.com/gcNFFlk.jpg" alt="Painel inicial do colaborador" height="200">
  </a>
    <a href="https://i.imgur.com/i5ifyEX.jpg">
    <img src="https://i.imgur.com/i5ifyEX.jpg" alt="Reservando Equipamentos" height="200">
  </a>
</p>



### **Funcionalidades**

O sistema possui dois niveis de acesso sendo eles como Usuário colaborador e administrador. Segue logo abaixo as funcionalidades de cada um deles na aplicação.

## Administrador
-   Cadastrar colaboradores e definir a permissão (administrador ou colaborador)
-   Gerenciar Horário
-   Gerenciar Equipamentos
-   Realizar Reservas
-   Entregar Equipamentos reservados
-   Coletar Equipamentos
-   Cancelar Reserva

## Colaborador
-   Solicitar a reserva de equipamentos ou laboratórios
-   Verificar disponibilidade dos equipamentos
-   Cancelar a própia reserva
-   Consultar as reservas solicitadas e equipamento em uso

### **Tecnologias**

#### Backend (API RESTFul)

-   Asp.Net 5
-   C#
-   Entity Framework
-   JWT
-   Asp.Net Core Identity
-   Banco de dados: MySQL
-   Swagger (Documentação)
-   Docker Compose
-   Implantação: Azure

#### Frontend

-   Typescript
-   React
-   CSS
-   Axios
-   Toastify

### Autor
Allison Sousa Bahls
<p>https://www.linkedin.com/in/allison-bahls/</p>
