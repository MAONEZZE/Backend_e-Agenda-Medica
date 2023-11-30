describe('Primeiro acesso à pagina de login', () => {
  it('Deve redirecionar à pagina de login', () => {
    cy.visit('/');

    cy.url().should('contain', 'login');
  });

  it('Deve mostrar notificação de email não preenchido', () => {
    cy.visit('/');

    //document.querySelector('.classe') assim pega todos os componentes que implementam a classe .classe
    //cy.get('[formControlName=email]') -> no html caso seja alguma tag ou classe tem que estar entre colchetes
    //cy.get('#id')
    cy.get('button[type=submit]').click();

    cy.contains('o campo email é obrigatório');
  });

  it('Deve mostrar notificação de senha não preenchida', () => {
    cy.visit('/');

    cy.get('[formControlName=email]').type('teste@gmail.com');// isso serve para deixar mais rápido o teste
                                                              // por exemplo aqui eu quero capturar se aparece o toastr da senha
                                                              // e para isso eu teria que ficar digitando o email e clicando em entrar 
                                                              // assim o cypress ja deixa um email valido no campo email para testar mais rapido

    cy.get('button[type=submit]').click();
    cy.contains('o campo senha é obrigatório')
  });

  it('Deve logar e redirecionar usuário para o dashboard', () => {
    cy.visit('/');

    cy.get('[formControlName=email]').type('ruansanchez@gmail.com');
    cy.get('[formControlName=senha]').type('Ruan@123');

    cy.get('button[type=submit]').click();
    cy.url().should('contain', 'dashboard');
  });
})