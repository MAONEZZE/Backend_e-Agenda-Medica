export class RegistrarSetup{
  public static obterRegistroTest(){
    return {
      nome: () => cy.get('[data-cy=nome]'),
      email: () => cy.get('[data-cy=email]'),
      login: () => cy.get('[data-cy=login]'),
      senha: () => cy.get('[data-cy=senha]')
    }
  }
}