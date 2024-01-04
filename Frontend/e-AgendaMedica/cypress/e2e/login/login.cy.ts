import { LoginSetup } from "./login-test.setup";

describe('Primeiro acesso à pagina de login', () => {
  beforeEach(() => {
    cy.visit('/');
  });

  it('Deve redirecionar à pagina de login', () => {
    cy.url().should('contain', 'login');
  });

  it('Deve mostrar notificação de nome de usuario não preenchido', () => {
    //document.querySelector('.classe') assim pega todos os componentes que implementam a classe .classe
    //cy.get('[formControlName=email]') -> no html caso seja alguma tag ou classe tem que estar entre colchetes
    //cy.get('#id')
    cy.get('[data-cy=btnEntrar]').click();

    cy.contains('O campo "login" é obrigatório');
  });

  it('Deve mostrar notificação de senha não preenchida', () => {
    const form = LoginSetup.obterLoginForm();

    form.login().type('userTeste', { force: true });

    cy.get('[data-cy=btnEntrar]').click();
    cy.contains('O campo "senha" é obrigatório')
  });

  it('Deve logar e redirecionar usuário para o dashboard', () => {
    const form = LoginSetup.obterLoginForm();

    form.login().type('ruanSanchez', { force: true });
    form.senha().type('Ruan@123', { force: true });

    cy.get('[data-cy=btnEntrar]').click();
    cy.url().should('contain', 'dashboard');
  });
})