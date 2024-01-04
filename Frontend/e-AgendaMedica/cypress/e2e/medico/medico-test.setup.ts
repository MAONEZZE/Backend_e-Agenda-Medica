export class MedicoSetup{
  public static obterMedicoForm() {
    return {
      nome: () => cy.get('[data-cy=nome]'),
      cpf: () => cy.get('[data-cy=cpf]'),
      crm: () => cy.get('[data-cy=crm]'),
    }
  }
}