import { Routes, Route } from "react-router-dom";
import Missing from "./scenes/missing";
import Navbar from "./scenes/global/Navbar";
import Characters from "./scenes/characters";
import CharacterProfile from "./scenes/characterProfile";
import CharacterSearch from "./scenes/characterSearch";

function App() {
  return (
    <>
      <div className="app">
        <main className="content">
          <Navbar />
          <Routes>
            <Route path="/" element={<Characters />} />
            <Route path="/Characters" element={<Characters />} />
            <Route path="/Characters/:characterId" element={<CharacterProfile />} />
            <Route path="/Characters/Search" element={<CharacterSearch />} />
            <Route path="*" element={<Missing />} />
          </Routes>
        </main>
      </div>
    </>
  );
}

export default App;
