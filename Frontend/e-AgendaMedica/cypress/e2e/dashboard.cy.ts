describe('Primeiro acesso à aplicação', () => {
  it('Deve redirecionar para o dashboard', () => {
    cy.visit('/')

    //A Url deve conter dashboard
    cy.url().should('contain', 'dashboard')
  })
})
