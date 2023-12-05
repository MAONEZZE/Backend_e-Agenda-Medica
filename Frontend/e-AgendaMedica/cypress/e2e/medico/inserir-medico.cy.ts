import '../../support/commands';

describe('Processo de cadastro de medico', () => {
  beforeEach(() => {
    cy.logar('ruanSanchez', 'Ruan@123');
    cy.contains('a', 'medical_services').click();
  });

  it('Deve entrar na pagina corretamente', () => {
    cy.get('[data-cy=btnAdd]').click();

    cy.url().should('contain', '/medicos/inserir');

    cy.get('[data-cy=nome]').type('medTeste', { force: true });
    cy.get('[data-cy=cpf]').type('123.333.222-55', { force: true });
    cy.get('[data-cy=crm]').type('65446-MG', { force: true });

    cy.get('[data-cy=btnGravar]').click();

    cy.url().should('contain', '/medicos/listar');
  });


});