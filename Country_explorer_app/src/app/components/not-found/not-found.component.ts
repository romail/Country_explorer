import { Component } from '@angular/core'

@Component({
  template: `
    <div>
      <h1>404 - Not Found</h1>
      <p>The page you are looking for doesn't exist.</p>
    </div>
  `,
  styles: [
    `
      div {
        text-align: center;
        padding: 20px;
      }

      h1 {
        color: red;
      }
    `
  ]
})
export class NotFoundComponent {}
