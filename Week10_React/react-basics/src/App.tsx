import React from 'react';
import './App.css';
import ComponentOne from './components/ComponentOne/ComponentOne';
import ComponentTwo from './components/ComponentTwo/ComponentTwo';
import ComponentThree from './components/ComponentThree/ComponentThree';
import ListDemo from './components/ListDemo/ListDemo';
import EventsDemo from './components/EventsDemo/EventsDemo';

/*
  We work with Functional Components for the most part in React, although there are Class Components.

  The reason why we use Functional Components over class components is because of two reasons, FCs are being pushed by React and so a lot of the features with React are built around it. It is also faster and more efficient than Class Components.


  What is a Component?
    - Snippet of HTML, CSS, and JS (TS)
    - Building blocks for the HTML page
    - Two types
        - Functional
        - Class

    We cannot have both, as they are essentially equivalent but implemented quite differently.
    In the long run we need to learn both, but for now the focus is on functional components.
*/

// class App extends React.Component {
//   render(): React.ReactNode {
//     return (
//       <div className="App">
//         <h1>Hello!</h1>
//       </div>
//     )
//   }
// }

function App() : React.JSX.Element {
  // The body of the function
  // In here, you will do all of your logic regarding the component
  return (
    // This return statement, contains the body of the component
    // And what will be displayed to the page

    /*
      Whatever we return, it has to be a root element. Meaning, you cannot have any siblings inside the return, they have to be nested inside a parent.
    */
    <div className="App">
        <ComponentTwo/>
        <ComponentOne/>
        <ComponentTwo/>
        <EventsDemo/>
        <ListDemo/>
    </div>
  );
}

export default App;