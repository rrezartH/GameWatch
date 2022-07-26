import './App.css';
import './styles/style.scss'
import './styles/_variables.scss'
import LandingPage from './features/landing-page/landing-page';
import Navbar from './components/navbar/navbar';
import Footer from './components/footer/footer';

function App() {
  return (

    <>
      <div className="container">
        <Navbar />
        <LandingPage />
      </div>
      <Footer />
    </>
  );
}

export default App;
