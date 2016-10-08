$(document).ready(function () {
    //$('input.typeahead').typeahead({
    //    team: [
    //    'Arizona Cardinals',
    //    'Atlanta Falcons',
    //    'Baltimore Ravens',
    //    'Buffalo Bills',
    //    'Carolina Panthers',
    //    'Chicago Bears',
    //    'Cincinnati Bengals',
    //    'Cleveland Browns',
    //    'Dallas Cowboys',
    //    'Denver Broncos',
    //    'Detroit Lions',
    //    'Greenbay Packers',
    //    'Houston Texans',
    //    'Indianapolis Colts',
    //    'Jacksonville Jaguars',
    //    'Kansas City Chiefs',
    //    'LosAngeles Rams',
    //    'Miami Dolphins',
    //    'Minnesota Vikings',
    //    'New England Patriots',
    //    'New Orleans Saints',
    //    'New York Giants',
    //    'New York Jets',
    //    'Oakland Raiders',
    //    'Philadelphia Eagles',
    //    'Pittsburgh Steelers',
    //    'San Diego Chargers',
    //    'San Francisco 49ers',
    //    'Seattle Seahawks',
    //    'Tampa Bay Buccaneers',
    //    'Tennessee Titans',
    //    'Washington Redskins'
    //    ]
    //});
   
    $(window).scroll(function () {
        if ($(this).scrollTop() > 250) {
            $('.scrollToTop').fadeIn();
        } else {
            $('.scrollToTop').fadeOut();
        }
    });

    $('.scrollToTop').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 1000);
        return false;
    });

});