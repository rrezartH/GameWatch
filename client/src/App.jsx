import './App.css';
import './styles/style.scss'
import './styles/_variables.scss'
import {Route, Routes} from "react-router-dom"
import LandingPage from './features/landing-page/landing-page';
import Navbar from './components/navbar/navbar';
import Footer from './components/footer/footer';
import Register from './features/register/register';
import Dashboard from './features/dashboard/dashboard';
import LokaliInterface from './features/lokali-interface/LokaliInterface';

function App() {
  return (
    <>
      <div className="container">
        <Navbar />
        <Routes>
          <Route path='/' element={<LandingPage />} />
          <Route path='/Register' element={<Register />} />
          <Route path='/Dashboard/*' element={<Dashboard />} />
          <Route path='/Lokali/*' element={<LokaliInterface />} />
        </Routes>
      </div>
      <Footer />
    </>
  );
}

export default App;
