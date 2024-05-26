<?php

class Person
{
    private $arGithubEventPrepared;
    private $arGithubEvent;

    public function __construct($id_pessoa)
    {
        $this->arGithubEventPrepared = [];
        $this->arGithubEvent = [];

        $start_time = microtime(true);
        

        $this->loadData();
        $this->prepareData();
        // $this->findPerson($id_pessoa);
        $this->searchPerson($id_pessoa);
        

        $end_time = microtime(true);
        $elapsed = $end_time - $start_time;
        echo "Total time [benchmark]: " . ($elapsed * 1000) . " ms\n"; // Display total time in milliseconds

    }

    private function loadData()
    {
        $start_time = microtime(true);
        
        $json = file_get_contents("/var/www/html/filmesApi/Controllers/TextArrayList/large-file.json");
        $this->arGithubEvent = json_decode($json, true);
        
        $end_time = microtime(true);
        $elapsed = $end_time - $start_time;
        echo "loadData [benchmark]: " . ($elapsed * 1000) . " ms \n"; // Display total time in milliseconds
    }

    private function prepareData()
    {
        $start_time = microtime(true);
        foreach ($this->arGithubEvent as $githubEvent) {
            $this->arGithubEventPrepared[$githubEvent['id']] = $githubEvent;
        }
        $end_time = microtime(true);
        $elapsed = $end_time - $start_time;
        echo "prepareData [benchmark]: " . ($elapsed * 1000) . " ms \n"; // Display total time in milliseconds
    }

    private function findPerson($id_pessoa)
    {
        $start_time = microtime(true);
        if (isset($this->arGithubEventPrepared[$id_pessoa])) {
            // print_r ($this->arGithubEventPrepared[$id_pessoa]);
        } else {
            echo "Event not found with id: " . $id_pessoa;
        }
        $end_time = microtime(true);
        $elapsed = $end_time - $start_time;
        echo "findPerson [benchmark]: " . ($elapsed * 1000) . " ms \n"; // Display total time in milliseconds
    }

    private function searchPerson($id_pessoa)
    {
        $start_time = microtime(true);
        
        foreach ($this->arGithubEvent as $githubEvent) {
            if ($githubEvent['id'] == $id_pessoa) {
                // print_r($githubEvent); // Uncomment to print the found event
                $found = true;
                break; // Exit the loop after finding the event
            }
        }

        $end_time = microtime(true);
        $elapsed = $end_time - $start_time;
        echo "findPerson [benchmark]: " . ($elapsed * 1000) . " ms \n"; // Display total time in milliseconds
    }
}

new Person('2489678844');
