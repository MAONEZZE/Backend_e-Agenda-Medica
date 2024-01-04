import '../../support/commands';
import { MedicoSetup } from './medico-test.setup';

describe('Processo de cadastro de medico', () => {
  beforeEach(() => {
    cy.logar('ruanSanchez', 'Ruan@123');
    cy.contains('a', 'medical_services').click();
  });

  it('Deve entrar na pagina corretamente', () => {
    cy.get('[data-cy=btnAdd]').click();

    cy.url().should('contain', '/medicos/inserir');
  });

  it('Deve entrar na pagina corretamente', () => {
    const form = MedicoSetup.obterMedicoForm();

    form.nome().type('medTeste', { force: true });
    form.cpf().type('123.333.222-55', { force: true });
    form.crm().type('65446-MG', { force: true });

    cy.get('[data-cy=btnGravar]').click();

    cy.url().should('contain', '/medicos/listar');
  });


});