describe('Primeiro acesso à pagina de login', () => {
  it('Deve redirecionar à pagina de login', () => {
    cy.visit('/');

    cy.url().should('contain', 'login');
  });

  it('Deve mostrar notificação de nome de usuario não preenchido', () => {
    cy.visit('/');

    //document.querySelector('.classe') assim pega todos os componentes que implementam a classe .classe
    //cy.get('[formControlName=email]') -> no html caso seja alguma tag ou classe tem que estar entre colchetes
    //cy.get('#id')
    cy.get('[data-cy=btnEntrar]').click();

    cy.contains('O campo "login" é obrigatório');
  });

  it('Deve mostrar notificação de senha não preenchida', () => {
    cy.visit('/');

    cy.get('[data-cy=txtLogin]').type('userTeste', { force: true });

    cy.get('[data-cy=btnEntrar]').click();
    cy.contains('O campo "senha" é obrigatório')
  });

  it('Deve logar e redirecionar usuário para o dashboard', () => {
    cy.visit('/');

    cy.get('[data-cy=txtLogin]').type('ruanSanchez', { force: true });
    cy.get('[data-cy=txtSenha]').type('Ruan@123', { force: true });

    cy.get('[data-cy=btnEntrar]').click();
    cy.url().should('contain', 'dashboard');
  });
})