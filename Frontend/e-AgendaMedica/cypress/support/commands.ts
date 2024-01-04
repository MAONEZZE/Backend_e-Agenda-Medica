declare namespace Cypress{

  interface Chainable<Subject = any>{
    logar(login: string, senha: string): typeof logar;
  }

}

function logar(login: string, senha: string){
  cy.visit('/');

  cy.get('[data-cy=login]').type(login, { force: true });
  cy.get('[data-cy=senha]').type(senha, { force: true });

  cy.get('[data-cy=btnEntrar]').click();
  cy.url().should('contain', 'dashboard');
};

Cypress.Commands.add('logar', logar);