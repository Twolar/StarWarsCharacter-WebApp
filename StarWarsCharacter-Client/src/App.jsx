import { Routes, Route } from "react-router-dom";
import Landing from "./scenes/landing";
import Missing from "./scenes/missing";
import Navbar from "./scenes/global/Navbar";

function App() {
  return (
    <>
      <div className="app">
        <main className="content">
          <Navbar />
          <Routes>
            <Route path="/" element={<Landing />} />
            <Route path="*" element={<Missing />} />
          </Routes>
        </main>
      </div>
    </>
  );
}

export default App;
